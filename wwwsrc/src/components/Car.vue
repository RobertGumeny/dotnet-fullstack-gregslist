<template>
  <div class="car card" style="width: 18rem;">
    <img :src="CarData.imgUrl" alt="Image of Car" class="card-img-top p-1" />
    <div class="card-body">
      <h4 class="card-title">{{CarData.make}}</h4>
      <h5 class="card-title">{{CarData.model}}</h5>
      <p class="card-text">{{CarData.year}}</p>
      <p class="card-text">${{CarData.price}}</p>
      <p class="card-text text-muted">{{CarData.description}}</p>
    </div>
  </div>
</template>


<script>
export default {
  name: 'car',
  props: ['CarData'],
  data() {
    return {}
  },
  computed: {},
  methods: {},
  components: {}
}
</script>


<style scoped>
</style>