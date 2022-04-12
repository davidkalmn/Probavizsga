<template>
    <div class="container">
        <div class="start w-100">
            <h1 class="text-center pt-2 pt-lg-4">Á.L.B. Ingatlanügynöség</h1>
            <div class="row">
                <div class="col-12 col-sm-6 text-center">
                    <!-- <a class="btn btn-primary" href="#">Nézze meg kínálatunkat!</a> -->
                   <router-link to="/offers" class="btn btn-primary">Nézze meg kínálatunkat!</router-link>
                </div>
                <div class="col-12 col-sm-6 text-center">
                    <!-- <a class="btn btn-primary" href="#">Hirdessen nálunk!</a> -->
                    <router-link to="/newad" class="btn btn-primary">Hirdessen nálunk!</router-link>
                </div>
            </div>
        </div>
    </div>
</template>


<style scoped>
.start {
    background-image: url('../assets/real-estate-agent.png');
    background-position: center;
    background-size: cover;
    min-height: 100vh;
}

@media (min-width: 768px) {
    .start {
        min-height: calc(100vh - 4rem);
    }
}

.start .btn {
    width: 14rem;
}

.start .row {
    margin-top: 60vh;
}

@media (max-width: 575px) {
    .start .row .col-12{
        margin: 2vh 0;
    }

    .start .row {
        margin-top: 35vh;
    }

    .start .row .btn {
        min-width: 15rem;
        font-size: 1rem;
    }    
}

.start .row .btn {
    min-width: calc(100% - 4rem);
    font-size: 1.7vw;
}

.container {
    background-color: rgb(217, 243, 240);
    min-height: 100vh;
}

.container nav.navbar ul.navbar-nav li.nav-item a.active{
    color: rgb(71, 71, 150);
    font-weight: bold;
}

.card-header {
    color: rgb(217, 243, 240);    
}

.card-text {
    text-align: justify;
}

.card-img-bottom {
    max-height: 40vh;
    width: auto;
    max-width: 100%;
    margin: 0 auto;
}
</style>