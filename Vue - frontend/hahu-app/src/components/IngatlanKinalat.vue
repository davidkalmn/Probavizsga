<template>
  <div>
    <vue-good-table :columns="columns" :rows="rows">
      <template #table-row="props">
        <span v-if="props.column.field == 'kepUrl'">
          <img :src="props.row.kepUrl" class="rounded mx-auto d-block" alt="">
            
          
        </span>
      </template>
    </vue-good-table>
  </div>
</template>

<script>
import Axios from "axios";
export default {
  name: "my-component",
  data() {
    return {
      columns: [
        {
          label: "Kategória",
          field: "kategoriaNev",
        },
        {
          label: "Leírás",
          field: "leiras",
        },
        {
          label: "Hirdetés dátuma",
          field: "hirdetesDatuma",
          type: "date",
          dateInputFormat: "yyyy.MM.dd",
          dateOutputFormat: "yyyy.MM.dd",
        },
        {
          label: "Tehermentes",
          field: "tehermentes",
          type: "boolean",
          formatFn: this.formatFn,
          tdClass: this.tdClassFunc,
        },

        {
          label: "Kép",
          field: "kepUrl",
        },
      ],
      rows: [],
    };
  },
  methods: {
    formatFn: function (value) {
      if (value) {
        return "IGEN";
      } else {
        return "NEM";
      }
    },
    tdClassFunc(row) {
      if (row.tehermentes) {
        return "text-success fw-bold text-center align-middle";
      }
      return "text-danger fw-bold text-center align-middle";
    },
  },
  created() {
    Axios.get("http://localhost:5000/api/ingatlan")
      .then((response) => {
        this.rows = response.data;
      })
      .catch((err) => console.log(err));
  },
};
</script>
<style scoped>
img{
  height: 30vh;
}
</style>