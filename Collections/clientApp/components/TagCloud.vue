<template>
  <div class="p-2">

  </div>
</template>

<script>
export default {
  name: 'TagCloud',
  async asyncData({$axios}) {
    const tags = await $axios.get('tag')
  }
}
</script>

<style scoped>

</style>
