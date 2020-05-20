<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <cars></cars>
  </div>
</template>

<script>
import Cars from "../components/Cars.vue"
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { Cars }
};
</script>
