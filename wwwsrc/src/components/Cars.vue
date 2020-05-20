<template>
  <div class="Cars container-fluid">
    <div class="row">
      <div class="col-md-6 mx-auto">
        <form @submit.prevent="createCar()">
          <div class="form-group">
            <label for="make">Make</label>
            <input
              type="text"
              name="make"
              class="form-control"
              placeholder="Enter make..."
              v-model="newCar.make"
            />
          </div>
          <div class="form-group">
            <label for="model">Model</label>
            <input
              type="text"
              name="model"
              class="form-control"
              placeholder="Enter model..."
              v-model="newCar.model"
            />
          </div>
          <div class="form-group">
            <label for="year">Year</label>
            <input
              type="number"
              name="year"
              class="form-control"
              placeholder="2020"
              v-model="newCar.year"
            />
          </div>
          <div class="form-group">
            <label for="price">Price</label>
            <input
              type="number"
              name="price"
              class="form-control"
              placeholder="12500"
              v-model="newCar.price"
            />
          </div>
          <div class="form-group">
            <label for="imgUrl">Image</label>
            <input
              type="text"
              name="imgUrl"
              class="form-control"
              placeholder="Enter image URL..."
              v-model="newCar.imgUrl"
            />
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea
              name="description"
              cols="20"
              rows="5"
              maxlength="255"
              class="form-control"
              v-model="newCar.description"
            ></textarea>
          </div>
          <button type="submit" class="btn btn-primary">Add Car</button>
        </form>
      </div>
    </div>
    <div class="row justify-content-center my-2">
      <Car v-for="car in cars" :key="car.id" :CarData="car"></Car>
    </div>
  </div>
</template>


<script>
import Car from "./Car.vue"
export default {
  name: "Cars",
  data() {
    return {
      newCar: {}
    };
  },
  mounted() {
    this.$store.dispatch("getCars");
  },
  computed: {
    cars() {
      return this.$store.state.cars;
    }
  },
  methods: {
    createCar() {
      this.newCar.year = +this.newCar.year;
      this.newCar.price = +this.newCar.price;
      this.$store.dispatch("createCar", this.newCar)
    }
  },
  components: { Car }
};
</script>


<style scoped>
</style>