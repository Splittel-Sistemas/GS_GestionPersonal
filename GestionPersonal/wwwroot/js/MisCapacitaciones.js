const MisCapacitaciones = {
    template: `
<div>
    <div class="row">
        <div class="col-3">
            <div class="card mg-b-20 mg-lg-b-5">
                <div class="card-body">
                    <div class="schedule-group mt-2">
                        <router-link
                            v-for="(prog, prog_index) in capProg_list"
                            :to="{ name: 'details-capacitacion', params: { idCacitacion: prog.idCapProg } }"
                            :title="'ver: ' + prog.nombreCap"
                            :class="'schedule-item mb-2 bd-l bd-2 ' + ( idSelected +'' === prog.idCapProg+'' ? 'bd-warning active-tema' : 'bd-primary' )"
                            
                        >
                            <span>  {{ prog.folio }} </span>
                            <h6> {{ prog.nombreCap }}</h6>
                            <span v-if="prog.modalidad === 'MIX'"> Mixta </span>
                            <span v-if="prog.modalidad === 'VIR'"> Virtual </span>
                            <span v-if="prog.modalidad === 'PRE'"> Presencial </span>

                            <span v-if="prog.estatus === 1"> En proceso de diseño</span>
                            <span v-if="prog.estatus === 2"> Baja </span>
                            <span v-if="prog.estatus === 3"> Terminada </span>
                            <span v-if="prog.estatus === 4"> Publicada a participantes</span>

                        </router-link>
                    </div>
                    <!-- schedule-group -->
                </div>
                <!-- card-body -->
            </div>
            <!-- card -->
        </div>
            <!-- col -->
        <div class="col-9">
            <router-view></router-view>
        </div><!-- col -->
    </div>
</div>
    `,
    data: function () {
        return {
            capProg_list: [],
        }
    },
    watch: {
        $route(to, from) {

        }
    },
    mounted() {
        this.onCapCapProgListByeEmp();
    },
    methods: {
        onCapCapProgListByeEmp: async function () {
            await axios.get('../FormacionCapacitacion/CapCapProgListByeEmp/0', null, null).then(response => {
                this.capProg_list = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
    }
}



//componentes
//participante - details - kardex
Vue.component('participante-details-kardex', {
    props: ['idCapProg', 'idPersona', 'idCapTemplDetails', 'idVersion','modalidad'],
    template: `
<div class="profile-sidebar pd-lg-r-25">
    <div class="placeholder-media wd-100p wd-sm-55p wd-md-45p" v-if="capKardex === null">
        <div class="line"></div>
    </div>
    <div class="row" v-else>
        <div class="col-sm-3 col-md-2 col-lg">
            <div class="col-sm-3 col-md-2 col-lg">
                <div class="avatar avatar-xxl"><img src="https://via.placeholder.com/500" class="rounded-circle" alt=""></div>
            </div><!-- col -->
            <div class="col-sm-8 col-md-7 col-lg mg-t-20 mg-sm-t-0 mg-lg-t-25">
                <h5 class="mg-b-2 tx-spacing--1">{{ capKardex.nombre }}</h5>
                <p class="tx-color-03 mg-b-2">{{ capKardex.departamento }}</p>

                <p class="tx-13 tx-color-02 mg-b-25">{{ capKardex.puesto }}</p>
                
                <p class="tx-13 tx-color-02 mg-b-25" v-if="capKardex.comentarios.length > 0">{{ capKardex.comentarios }}</p>
                <hr>
                <div class="d-flex">
                    <div class="profile-skillset flex-fill">
                        <h4> {{ capKardex.calInicial }}</h4>
                        <label>Cal.Diagnostico</label>
                    </div>
                    <div class="profile-skillset flex-fill">
                        <h4> {{ capKardex.calFinal }}</h4>
                        <label>Cal.Final</label>
                    </div>
                </div>
                <hr>
                <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Estatus</label>
                <p class="mg-b-0" v-if="capKardex.estatus ===  1">En proceso</p>
                <p class="mg-b-0" v-if="capKardex.estatus ===  2">Concluida</p>

                <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10 mt-2">Intento</label>
                <p class="mg-b-0">{{  capKardex.intento }}</p>

                <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10 mt-2">Modalidad</label>
                <p class="mg-b-0" v-if="modalidad === 'MIX'"> Mixta</p>
                <p class="mg-b-0" v-if="modalidad === 'VIR'"> Virtual </p>
                <p class="mg-b-0" v-if="modalidad === 'PRE'"> Presencial</p>
                <hr>
                <capacitacion-template-version :idCapTemplDetails="idCapTemplDetails" :idVersion="idVersion"></capacitacion-template-version>
            </div><!-- col -->
            
        </div><!-- col -->
         
    </div><!-- row -->
</div><!-- profile-sliderbar -->
    `,
    data: function () {
        return {
            info: '',
            capKardex: null
        }
    },
    async mounted() {
        this.onCapKardexDetailsByEmp()
    },
    watch: {
        idCapProg: function (newVal, oldVal) { // watch it
            if (parseInt(newVal) !== parseInt(oldVal)) {
                this.onCapKardexDetailsByEmp()
            }
        }
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onCapKardexDetailsByEmp: async function () {
            this.capKardex = null
            await axios.get('../FormacionCapacitacion/CapKardexDetailsByEmp/' + this.idCapProg, null, null).then(response => {
                this.capKardex = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
            
        },
    }
})

Vue.component('capacitacion-template-version', {
    props: ['idCapTemplDetails', 'idVersion'],
    template: `
<dl class="row" style="font-size: 13px;" v-if="capTempl !== null">
    <dt class="col-12 tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">
        Clave
    </dt>
    <dd class="col-12" >
        {{ capTempl.clave }}
    </dd>
    <dt class="col-12 tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">
        Nombre
    </dt>
    <dd class="col-12">
        {{ capTempl.nombre }}
    </dd>
    <dt class="col-12 tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">
        Descripción
    </dt>
    <dd class="col-12">
        {{ capTempl.objetivo }}
    </dd>
    <dt class="col-12 tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">
        Objetivo
    </dt>
    <dd class="col-12">
        {{ capTempl.descripcion }}
    </dd>
    <dt class="col-12 tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">
        Calificación minima
    </dt> <dd class="col-12">
        {{ capTempl.calRepet }}
    </dd>
</dl> <!-- row--> 
    `,
    data: function () {
        return {
            info: '',
            capTempl: null
        }
    },
    async mounted() {
        this.onCapTemplDetails()
    },
    watch: {
        idCapTemplDetails: function (newVal, oldVal) { // watch it
            if (parseInt(newVal) !== parseInt(oldVal)) {
                this.onCapTemplDetails()
            }
        },
        idVersion: function (newVal, oldVal) { // watch it
            if (parseInt(newVal) !== parseInt(oldVal)) {
                this.onCapTemplDetails()
            }
        }
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onCapTemplDetails: async function () {
            this.capTempl = null
            await axios.get('../FormacionCapacitacion/CapTemplDetails?id=' + this.idCapTemplDetails +'&IdVersion=' + this.idVersion, null, null).then(response => {
                this.capTempl = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })

        },
    }
})


const Detalle = {
    template: `
<div class="content content-profile">
    <div class="container-fluid pd-x-0 pd-lg-x-10 pd-xl-x-0" v-if="capProg !==null ">
        <div class="media d-block d-lg-flex">

            <participante-details-kardex
                v-if="capProg !== null"
                :idCapTemplDetails="capProg.idCapTempl"
                :idVersion="capProg.idVersion"
                :modalidad="capProg.modalidad"
                :idCapProg="$route.params.idCacitacion"
            ></participante-details-kardex>
            <hr>
           
            <div class="media-body mg-t-40 mg-lg-t-0 pd-lg-x-10">
                
                <span v-if="capProg.estatus === 1"> En proceso de diseño</span>
                <span v-if="capProg.estatus === 2"> Baja </span>
                <span v-if="capProg.estatus === 3"> Terminada </span>
                <span v-if="capProg.estatus === 4"> Publicada a participantes</span>

                <router-view ></router-view>
            </div><!-- media-body -->

            <div class="profile-sidebar mg-t-40 mg-lg-t-0 pd-lg-l-25">
                <div class="row">
                    <div class="col-sm-6 col-md-5 col-lg">
                        <div class="d-flex align-items-center justify-content-between mg-b-20">
                          <h6 class="tx-13 tx-spacng-1 tx-uppercase tx-semibold mg-b-0">Stories</h6>
                          <a href="" class="link-03">Watch All</a>
                        </div>
                        <ul class="list-unstyled media-list mg-b-15">
                          <li class="media align-items-center">
                            <a href=""><div class="avatar avatar-online"><span class="avatar-initial rounded-circle bg-dark">S</span></div></a>
                            <div class="media-body pd-l-15">
                              <p class="tx-medium mg-b-0"><a href="" class="link-01">Socrates Itumay</a></p>
                              <span class="tx-12 tx-color-03">2 hours ago</span>
                            </div>
                          </li>
                        </ul>
                        <a href="" class="link-03 d-inline-flex align-items-center">See more stories <i class="icon ion-ios-arrow-down mg-l-5 mg-t-3 tx-12"></i></a>
                    </div><!-- col -->
                </div><!-- row -->            
            </div><!-- profile-sidebar -->
        </div><!-- media block -->
    </div><!-- container-fluid -->
</div><!-- contetent -->
    `,
    data: function () {
        return {
            capProg: null,
        }
    },
    watch: {
        $route(to, from) {

        }
    },
    async mounted() {
        await this.onCapProgdetails();
    },
    methods: {
        
        onCapProgdetails: async function () {
            this.capProg = null
            await axios.get('../FormacionCapacitacion/CapProgdetails?IdCapProg=' + this.$route.params.idCacitacion, null, null).then(response => {
                this.capProg = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        
    }
}
const details_capacitacion_agenda = {
    template: `
<div>
<div class=" mg-b-10 mg-lg-b-15 mg-t-25" v-for="(shed, shed_index) in  capProgSheduleListProg">
    <div class="">
        <div class="media align-items-center mg-b-20">
            <div :class="'wd-45 ht-45 rounded d-flex align-items-center justify-content-center ' + (shed.tipoShedule === 'SES' ? 'bg-dark' : 'bg-primary')">
                <i class="tx-white-7 wd-20 ht-20 typcn typcn-document"></i>
            </div>
            <div class="media-body pd-l-15">
                <h6 class="mg-b-3">{{ shed.nombreStep }}</h6>
                <span class="d-block tx-13 tx-color-03" v-html="validEvaContraint(shed)"></span>
                <span class="d-block tx-13 tx-color-03" v-if="shed.modalidad === 'MIX'"> Mixta </span>
                <span class="d-block tx-13 tx-color-03" v-if="shed.modalidad === 'VIR'"> Virtual </span>
                <span class="d-block tx-13 tx-color-03" v-if="shed.modalidad === 'PRE'"> Presencial </span>
                <a class="linkds" v-if="shed.tipoShedule === 'SES'">Ver contenido</a>
            </div>
            <span class="d-none d-sm-block tx-12 tx-color-03 align-self-start"></span>
        </div><!-- media -->
    </div><!-- card-body -->
    <hr style="margin-bottom: 0rem !important;margin-top: 0rem !important;">
</div><!-- card -->
</div>
    `,
    data: function () {
        return {
            capProgSheduleListProg: []
        }
    },
    watch: {
        $route(to, from) {

        }
    },
    async mounted() {
        await this.onCapProgSheduleListProg();
    },
    methods: {
        onCapProgSheduleListProg: async function () {
            this.capProgSheduleListProg = []
            await axios.get('../FormacionCapacitacion/CapProgSheduleListProg?IdCapProg=' + this.$route.params.idCacitacion, null, null).then(response => {
                this.capProgSheduleListProg = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        validEvaContraint: function (local_shed) {
            if (local_shed.tipoShedule === 'EVA') {
                return `Horario de <b>${local_shed.inicioFormat}</b> a <b>${local_shed.finFormat} </b>, Duración: <strong>${local_shed.durFormat}</strong> hrs`
            } else {
                return `Horario de <b>${local_shed.inicioFormat}</b> a <b>${local_shed.finFormat} </b>, Duración: <strong>${local_shed.durFormat}</strong> hrs`
            }

        },
    }
}
const routes = [
    {
        path: '/',
        component: MisCapacitaciones,
        
    },
    {
        name:'details-capacitacion',
        path: '/details-capacitacion/:idCacitacion',
        component: Detalle,
        children: [
            {
                name: 'details-capacitacion-agenda',
                path: 'agenda',
                component: details_capacitacion_agenda
            }
        ]
    }
]

const router = new VueRouter({
    routes, // short for `routes: routes`
})

const app = new Vue({
    router
}).$mount('#app')