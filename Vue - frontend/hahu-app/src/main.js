import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'
import OpenPage from "./components/OpenPage.vue";
import IngatlanKinalat from "./components/IngatlanKinalat.vue";

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {path: '/', component: OpenPage},
        { path: '/offers', IngatlanKinalat }
    ]
})

const app = createApp(App)
app.use(router)

app.mount("#app")
