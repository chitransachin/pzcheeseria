import axios from "axios";
export default {
  getAllCheese() {
    //Fetches a list of all available Cheese from the store
    console.log("Started fetching cheese");
    const url = `https://localhost:44311/Cheese`;

    var cheeseItems = [];
    this.loading = true;

    axios
      .get(url)
      .then((response) => {
        console.table(response.data);

        response.data.map((cheese) => {
          cheese.totalUnits = 1;
          cheeseItems.push(cheese);
        });
      })
      .catch((error) => {
        console.log(error);
        this.errored = true;
      })
      .finally(() => (this.loading = false));

    return cheeseItems;
  },
  createCheese() {
    //Add code to do an API post call to create a new Cheese entry
  },
  getPremiumCheese() {
    //Add code to get only premium cheese
  },
  deleteCheese(id) {
    console.log("Deleting id " + id);
    //Add code to delete Cheese
  },
};
