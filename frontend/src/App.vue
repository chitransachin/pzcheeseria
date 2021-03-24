<template>
  <div id="app">
    <div>
      <h1 class="display-3 my-3 font-weight-thin white--text my-5">
        Cheese favourites from our Store
      </h1>
      <b-card-group deck>
        <b-card
          no-body
          v-for="(cheese, i) in items"
          :key="i"
          v-bind:title="cheese.commonName"
          v-bind:img-src="cheese.cheeseImage"
          style="max-width: 20rem"
          img-alt="Image"
          img-top
        >
          <b-card-body>
            <b-card-title>{{ cheese.commonName }}</b-card-title>
            <b-card-sub-title class="mb-2"
              >Family : {{ cheese.family }}</b-card-sub-title
            >
            <b-card-text>
              {{ cheese.cheeseDescription }}
            </b-card-text>
          </b-card-body>

          <b-list-group flush>
            <b-list-group-item
              >Source: {{ cheese.animalSource }}</b-list-group-item
            >
            <b-list-group-item>Colour: {{ cheese.colour }}</b-list-group-item>
            <b-list-group-item>Aroma: {{ cheese.aroma }}</b-list-group-item>
            <b-list-group-item>
              <b-form-rating v-model="cheese.qualityScore"></b-form-rating>
            </b-list-group-item>
          </b-list-group>

          <b-card-body>
            <div>
              <span>Enter quantiy required</span>
              <input
                v-model="cheese.totalUnits"
                type="number"
                placeholder="Enter quantity required"
              />
            </div>
            <div>
              <span style="display: block">Price in kilo ($)</span>
              <input
                v-model="cheese.pricePerKilo"
                type="number"
                readonly="true"
                placeholder="Price per kilo"
              />
            </div>
            <div class="mt-2">
              <h3>
                Total cost
                <b-badge>{{
                  Math.round(
                    cheese.pricePerKilo *
                      (parseInt(cheese.totalUnits) || 1) *
                      100
                  ) / 100
                }}</b-badge>
              </h3>
            </div>
          </b-card-body>

          <b-card-footer>Made in {{ cheese.country }}</b-card-footer>
        </b-card>
      </b-card-group>
    </div>
  </div>
</template>

<script>
import cheeseapi from "@/cheeseapi";

export default {
  name: "app",
  components: {},
  data() {
    return {
      items: [],
      loading: false,
    };
  },
  created() {
    this.items = cheeseapi.getAllCheese();
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Lato:400,700");
body {
  background: #eef1f4 !important;
  font-family: "Lato", sans-serif !important;
}
.nav-background {
  background: #353535;
}
</style>