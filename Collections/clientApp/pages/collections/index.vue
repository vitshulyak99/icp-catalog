<template>
  <section>
    <ul>
      <li v-for="(i,idx) of 5" :key="idx">
        <a href="#" @click.prevent="()=>$router.push('collections/' + i)">a {{i}}</a>
      </li>
    </ul>
  </section>
</template>

<script>
export default {
  name: 'index'
}
</script>

<style scoped>

</style>
