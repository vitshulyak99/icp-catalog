<template>
  <section>
    <h1> A {{$route.params.id}}</h1>
  </section>
</template>

<script>
export default {
  validate:({params}) => /\d+/.test(params.id)
}
</script>

<style scoped>

</style>
