const CLOUDINARY_URL = "https://api.cloudinary.com/v1_1/dhykxsrjn/upload";
const CLOUDINARY_UPLOAD_PRESET = "xsbojoov";
const CREATE_COLLECTION_POST_URL = `${location.origin}/collection/Create`;

function checkUncheckAll(className) {
    return el => {
        const arrEl = Array.prototype.slice.call($(`.${className}`));
        arrEl.forEach(x => x.checked = el.checked);
    }
}

function createImageUploadHandler(prev) {
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
        }).then(request => {
            prev.src = request.data.url;
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
        image: $('#img-preview')[0].src,
        title: $('#title').val(),
        description: $('#description').val(),
        theme: $("#theme").val(),
        fields: Object.values($('#customfields')[0].fields)
    }
    axios.post(CREATE_COLLECTION_POST_URL, createModel)
        .catch(console.log);
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
        console.log(container[0].fields);
        
        btn.onclick = () => {
            fields[field.id] = undefined;
             clone.remove();
        }
        container[0].append(field);
        field.hidden = false;
        
    }
}

function deleteCollection(id) {
    return e => {
        console.log(e);
        axios.post(`${location.origin}/collection/delete/${id}`);
    }
}