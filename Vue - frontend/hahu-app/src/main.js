import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'
import OpenPage from "./components/OpenPage.vue";
import IngatlanKinalat from "./components/IngatlanKinalat.vue";

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap'

import VueGoodTablePlugin from 'vue-good-table-next';
import 'vue-good-table-next/dist/vue-good-table-next.css'



const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', component: OpenPage},
        { path: '/offers', component: IngatlanKinalat }
    ]
})

const app = createApp(App)
app.use(router)
app.use(VueGoodTablePlugin);

app.mount("#app")
