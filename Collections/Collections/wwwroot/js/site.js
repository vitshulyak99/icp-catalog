const CLOUDINARY_URL = "https://api.cloudinary.com/v1_1/dhykxsrjn/upload";
const CLOUDINARY_UPLOAD_PRESET = "xsbojoov";
const CREATE_COLLECTION_POST_URL = `${location.origin}/collection/Create`;

function checkUncheckAll(className) {
    return el => {
        const arrEl = Array.prototype.slice.call($(`.${className}`));
        arrEl.forEach(x => x.checked = el.checked);
    }
}

function createImageUploadHandler(prev, input) {
    return e => {
        const file = e.target.files[0];
        const formData = new FormData();
        formData.append("file", file);
        formData.append("upload_preset", CLOUDINARY_UPLOAD_PRESET);

        axios({
            url: CLOUDINARY_URL,
            method: "POST",
            headers: {
                'Content-Type': "application/x-www-form-urlencoded"
            },
            data: formData
        }).then(resp => {
            prev.src = resp.data.url;
            input.value = resp.data.url
        }).catch(console.log);
    }
}

function Editor(input, preview) {
    this.md = new markdownit({
        html: true,
        breaks: true,
        linkify: true
    });
    this.update = () => {
        preview.innerHTML = this.md.render(input.value)
    };
    input.editor = this;
    this.update();
}

function collectionCreateSubmit() {
    const createModel = {
        title: $('#title').val(),
        image: $('#img-preview')[0].src,
        theme: +$("#theme").val(),
        description: $('#description').val(),
        Fields: Object.values($('#customfields')[0].fields),
        ownerName: null
    }
    axios.post(CREATE_COLLECTION_POST_URL, createModel)
        .then(req => {
            location.href = req.data.redirectionUrl
        }).catch(console.log)
}

function fieldCreator(customField, container) {
    const fields = {}
    container[0].fields = fields;
    return e => {
        const field = customField.clone()[0];
        const div = document.createElement("div");
        const btn = document.createElement("button");
        btn.textContent = "Delete";
        btn.classList.add("btn");
        btn.classList.add("btn-light");
        div.append(btn);
        field.append(div);
        div.classList.add("col-1");
        field.id = new Date().getMilliseconds().toString();
        const select = field.children[0].children[0];
        const input = field.children[1].children[0];
        const fieldValue = { type: '', name: '' };
        fields[field.id] = fieldValue;
        input.update = () => fieldValue.name = input.value;
        input.oninput = e => input.update();
        select.update = () => fieldValue.type = select.value;
        select.update();
        select.onchange = e => select.update();
        btn.onclick = () => {
            fields[field.id] = undefined;
            field.remove();
        }
        container[0].append(field);
        field.hidden = false;

    }
}

function initItemCreateHandler() {
    this.fields = {}
    this.collectionId = -1
    this.name = ''
    this.tags = []
    this.bindName = e => {
        this.name = e.target.value
    }
    this.bindField = e => {
        const id = e.target.id
        const value = e.target.checked ? e.target.checked : e.target.value
        if (!this.fields[id]) this.fields[id] = { fieldId: id }
        this.fields[id] = value
    }
    this.bindTags = tags => this.tags = tags
    this.getReqBody = () => ({
        name: this.name,
        tags: this.tags,
        collectionId: this.collectionId,
        fields: Object.keys(this.fields).map(x => ({ fieldId: x, value: this.fields[x] }))
    })
    this.post = () => {
        const url = `${origin}/Item/CreatePost/${this.collectionId}`
        axios.post(url, this.getReqBody())
            .then(({ data }) => location.href = data.redirectionUrl)
    }
}

function tagifyInit(inputEl, tagOnChangeCallback) {

    const tagify = new Tagify(inputEl, {
        delimiters: null,
        callbacks: {
            add: onAddTag,
            remove: onRemoveTag,
            edit: onTagEdit,
            input: onInput,
            // invalid: onInvalidTag,
            // click: onTagClick,
            // focus: onTagifyFocusBlur,
            // blur: onTagifyFocusBlur,
            // 'dropdown:hide dropdown:show': e =>,
            //'dropdown:select': onDropdownSelect
        },
        dropdown: {
            classname: "color-blue",
            enabled: 0,
            maxItems: 5,
            position: "text",
            closeOnSelect: false,
            highlightFirst: true
        }
    })
    tagify.tagIds = {}


    function getValue() {
        return tagify.value.map(({ value }) => ({ id: tagify.tagIds[value], name: value }))
    }

    function onAddTag(e) {
        const values = getValue()
        tagOnChangeCallback(values)
    }

    function onRemoveTag(e) {
        const values = getValue()
        tagOnChangeCallback(values)
    }
    tagify.reqCancelSource = {
        cancel: () => {}
    }

    function onInput(e) {

        tagify.settings.whitelist.length = 0;
        tagify.loading(true)
        tagify.reqCancelSource.cancel()
        tagify.reqCancelSource = axios.CancelToken.source();
        axios.get(`${origin}/api/tag/like/${e.detail.value}`, { cancelToken: tagify.reqCancelSource.token }).then(result => {

            const sTags = result.data;
            sTags.forEach(({ id, name }) => tagify.tagIds[name] = id)
            const values = sTags.map(({ name }) => name)
            tagify.settings.whitelist = values
            tagify
                .loading(false)
                .dropdown.show.call(tagify);
        }).catch(e => tagify.loading(false))
    }

    function onTagEdit(e) {
        const values = getValue()
        tagOnChangeCallback(values)
    }

    return tagify
}

const likeEventHandlerCreator = (img,counter) =>  e => axios.get(origin + '/item/set').then(res=>{
    img.src = res.data ? "heart.png" : "heart-clicked.png"
    const c = Number.parseInt(counter.innerHTML)
    counter.innerHTML =  res.data ? c++ : c--
})