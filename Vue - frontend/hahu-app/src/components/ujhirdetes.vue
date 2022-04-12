<template>
    <div class="container">
        <h2 class="mb-4 text-center">Új hirdetés elküldése</h2>
        <div class="row">
            <div class="offset-lg-3 offset-md-2 col-lg-6 col-md-8 col-12">
                <div class="mb-3">
                    <label for="category" class="form-label">Ingatlan kategóriája</label>
                    <select class="form-select" name="kategoriaId" v-model="ujHirdetes.kategoriaId">
                        <option value="0">Kérem válasszon</option>
                        <option v-for="kategoria in kategoriak" :key="kategoria.id" :value="kategoria.id">{{ kategoria.megnevezes }}</option>
                        <!-- <option value="0">Kérem válasszon</option>
                        <option value="1">Ház</option>
                        <option value="2">Lakás</option>
                        <option value="3">Építési telek</option>
                        <option value="4">Garázs</option>
                        <option value="5">Mezőgazdasági terület</option>
                        <option value="6">Ipari ingatlan</option> -->
                    </select>
                </div>

                <div class="mb-3">
                    <label for="date" class="form-label">Hirdetés dátuma</label>
                    <input type="date" class="form-control" readonly name="hirdetesDatuma" v-model="ujHirdetes.hirdetesDatuma">
                </div>
                <div class="mb-3">
                    <label for="description" class="form-label">Ingatlan leírása</label>
                    <textarea class="form-control" name="leiras" v-model="ujHirdetes.leiras" rows="3"></textarea>
                </div>
                <div class="form-check mb-3">
                    <input class="form-check-input" type="checkbox" name="tehermentes" v-model="ujHirdetes.tehermentes" checked>
                    <label class="form-check-label" for="creditFree" >Tehermentes ingatlan</label>
                </div>
                <div class="mb-3">
                    <label for="pictureUrl" class="form-label">Fénykép az ingatlanról</label>
                    <input type="url" class="form-control" v-model="ujHirdetes.kepUrl" name="kepUrl">
                </div>
                <div class="mb-3 text-center">
                    <button class="btn btn-primary px-5" @click="save">Küldés</button>
                </div>

                <div class="alert alert-danger alert-dismissible" role="alert">
                    <strong>{{error}}</strong>
                    <button type="button" class="btn-close"></button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import  Axios  from 'axios';

export default {
    data() {
        return{
            ujHirdetes: {
                kategoriaId: 0,
                leiras: "",
                hirdetesDatuma: new Date().toISOString().substr(0,10),
                tehermentes: true,
                kepUrl: "",
            },
            kategoriak: [],
        }
    },
    methods: {
        save(){
            Axios.post('http://localhost:5000/api/ujingatlan', this.ujHirdetes)
            .then(response => {
                console.log(response.data)
                this.$router.push('/offers')
                })
            .catch(err => this.error = err)
        }
    },
    created(){
        Axios.get("http://localhost:5000/api/kategoriak")
        .then(response => this.kategoriak = response.data)
        .catch(err =>console.log(err))
    }
}
</script>
