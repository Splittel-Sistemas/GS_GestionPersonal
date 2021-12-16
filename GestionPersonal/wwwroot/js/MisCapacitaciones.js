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
                            :class="'schedule-item mb-2 bd-l bd-2 '"
                            
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

Vue.component('capacitacion-session', {
    props: ['idCapTempl', 'idVersion', 'idCapSess'],
    template: `
<div>
    <hr>
    <dl class="row" style="font-size: 13px;" v-if="capSess != null">
        <dt class="col-12">
            Objetivo
        </dt>
        <dd class="col-12">
            {{ capSess.objetivo }}
        </dd>
    </dl>
    <hr>
    <div class="media align-items-center mt-1" v-for="(tema_, tema_index) in capTemaList">
        <div class="media-body">
            <h6 class="mg-b-3">{{ tema_.nombre }}</h6>
            <p class="tx-13">{{ tema_.descripcion }}</p>
        </div>
        <span class="d-none d-sm-block tx-12 tx-color-03 align-self-start"></span>
    </div><!-- media -->
</div>
    `,
    data: function () {
        return {
            info: '',
            capSess: null,
            capTemaList: []
        }
    },
    async mounted() {
        this.onCapSessDetails()
        this.onCapTemaBySession()
    },
    watch: {
        idCapTempl: function (newVal, oldVal) { // watch it
            if (parseInt(newVal) !== parseInt(oldVal)) {
                this.onCapSessDetails()
                this.onCapTemaBySession()
            }
        },
        idVersion: function (newVal, oldVal) { // watch it
            if (parseInt(newVal) !== parseInt(oldVal)) {
                this.onCapSessDetails()
                this.onCapTemaBySession()
            }
        },
        idCapSess: function (newVal, oldVal) { // watch it
            if (parseInt(newVal) !== parseInt(oldVal)) {
                this.onCapSessDetails()
                this.onCapTemaBySession()
            }
        },
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onCapSessDetails: async function () {
            this.capSess = null
            await axios.get(`../FormacionCapacitacion/CapSessDetails?idVersion=${this.idVersion}&IdCapTempl=${this.idCapTempl}&IdCapSess=${this.idCapSess}`, null, null).then(response => {
                this.capSess = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapTemaBySession: async function () {
            this.capTemaList = []
            await axios.get(`../FormacionCapacitacion/CapTemaBySession?idVersion=${this.idVersion}&IdCapSess=${this.idCapSess}`, null, null).then(response => {
                this.capTemaList = response.data
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
                <div class="card mg-b-10" style="border: 0px;" v-if="capProgSheduleListProg.length > 0">
                    <div class="card-header pd-t-20 d-sm-flex align-items-start justify-content-between bd-b-0 pd-b-0">
                        <div>
                          <h6 class="mg-b-5">{{ capProgSheduleListProg[indexSelected].nombreStep }}</h6>
                          <p class="tx-13 tx-color-02 mg-b-0" v-html="validEvaContraint(capProgSheduleListProg[indexSelected],'')"></p>
                        </div>
                        <div class="d-flex mg-t-20 mg-sm-t-0">
                          <div class="btn-group flex-fill">
                            <button class="btn btn-white btn-xs" :disabled="indexSelected === 0" v-on:click="indexSelected--"><</button>
                            <button class="btn btn-white btn-xs" :disabled="(capProgSheduleListProg.length - 1) === indexSelected" v-on:click="indexSelected++">></button>
                          </div>
                        </div>
                    </div><!-- card-header -->
                    <div class="card-body pd-y-30" v-if="capProgSheduleListProg.length > 0 && capProg != null">
                        <capacitacion-session v-if="capProgSheduleListProg[indexSelected].tipoShedule === 'SES'"
                            :idVersion="capProgSheduleListProg[indexSelected].idVersion"
                            :idCapTempl="capProg.idCapTempl"
                            :idCapSess="capProgSheduleListProg[indexSelected].idRefer"></capacitacion-session>
                    </div>
                </div>
            </div><!-- media-body -->

            <div class="profile-sidebar mg-t-40 mg-lg-t-0 pd-lg-l-25">
                <div class="" v-for="(shed, shed_index) in  capProgSheduleListProg">
                    <div class="" v-if="shed.tipoShedule === 'EVA'">
                        <div class="media align-items-center mt-1">
                            <div class="media-body pd-l-15">
                                <h6 class="mg-b-3">{{ shed.nombreStep }}</h6>
                                <span class="d-block tx-13 tx-color-02" v-html="validEvaContraint(shed)"></span>
                                <span class="d-block tx-13 tx-color-02" v-if="shed.modalidad === 'MIX'"> Mixta </span>
                                <span class="d-block tx-13 tx-color-02" v-if="shed.modalidad === 'VIR'"> Virtual </span>
                                <span class="d-block tx-13 tx-color-02" v-if="shed.modalidad === 'PRE'"> Presencial </span>
                            </div>
                            <span class="d-none d-sm-block tx-12 tx-color-03 align-self-start"></span>
                        </div><!-- media -->
                    </div><!-- card-body -->
                    <hr v-if="shed.tipoShedule === 'EVA'" style="margin-bottom: 0rem !important;margin-top: 0rem !important;">
                </div><!-- card -->
            </div><!-- profile-sidebar -->
        </div><!-- media block -->
    </div><!-- container-fluid -->
</div><!-- contetent -->
    `,
    data: function () {
        return {
            capProg: null,
            indexSelected : 0,
            capProgSheduleListProg: []
        }
    },
    watch: {
        $route(to, from) {
            if (parseInt(from.params.idCacitacion) !== parseInt(to.params.idCacitacion)) {
                this.onCapProgSheduleListProg();
                this.onCapProgdetails();
            }
        }
    },
    async mounted() {
        await this.onCapProgdetails();
        await this.onCapProgSheduleListProg();
    },
    methods: {
        
        onCapProgdetails: async function () {
            this.capProg = null
            await axios.get('../FormacionCapacitacion/CapProgdetails?IdCapProg=' + this.$route.params.idCacitacion, null, null).then(response => {
                this.capProg = response.data
            }).catch(error => {
                if (error.response) {
                    if (error.response.status === 400)
                        router.push({ name: 'not-found', params: { message: error.response.data } })
                }
            }).finally(() => {

            })
        },
        onCapProgSheduleListProg: async function () {
            this.capProgSheduleListProg = []
            await axios.get('../FormacionCapacitacion/CapProgSheduleListProg?IdCapProg=' + this.$route.params.idCacitacion, null, null).then(response => {
                this.capProgSheduleListProg = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {
                //this.startCalendar();
            })
        },
        validEvaContraint: function (local_shed, salto = "<br>") {
            if (local_shed.tipoShedule === 'EVA') {
                return `Horario de <b>${local_shed.inicioFormat}</b> a <b>${local_shed.finFormat} </b>,${salto}Duración: <strong>${local_shed.durFormat}</strong> hrs`
            } else {
                return `Horario de <b>${local_shed.inicioFormat}</b> a <b>${local_shed.finFormat} </b>,${salto}Duración: <strong>${local_shed.durFormat}</strong> hrs`
            }

        },
        startCalendar: function () {
            // Initialize fullCalendar
            var events_sessiones = {
                id: 1,
                backgroundColor: 'rgba(1,104,250, .15)',
                borderColor: '#0168fa',
                events: []
            };
            this.capProgSheduleListProg.forEach((e, i) => {
                events_sessiones.events.push(
                    {
                        id: e.idCapProgShedule,
                        start: e.fechaFormat + 'T' + e.inicioFormat,
                        end: e.fechaFormat + 'T' + e.finFormat,
                        title: e.nombreStep,
                        description: e.nombreStep
                    }
                );
            })
            
            $('#cal_cap_' + this.$route.params.idCacitacion).fullCalendar({
                height: 'parent',
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay,listWeek'
                },
                navLinks: true,
                selectable: true,
                selectLongPressDelay: 100,
                editable: true,
                nowIndicator: true,
                defaultView: 'listMonth',
                views: {
                    agenda: {
                        columnHeaderHtml: function (mom) {
                            return '<span>' + mom.format('ddd') + '</span>' +
                                '<span>' + mom.format('DD') + '</span>';
                        }
                    },
                    day: { columnHeader: false },
                    listMonth: {
                        listDayFormat: 'ddd DD',
                        listDayAltFormat: false
                    },
                    listWeek: {
                        listDayFormat: 'ddd DD',
                        listDayAltFormat: false
                    },
                    agendaThreeDay: {
                        type: 'agenda',
                        duration: { days: 3 },
                        titleFormat: 'MMMM YYYY'
                    }
                },

                eventSources: [events_sessiones],
                
            });

        }
    }
}

const not_found = {
    template: `
<div>
    <h1>{{ $route.params.message }}</h1>
</div>
`,
}
const details_capacitacion_agenda = {
    template: `
<div>

</div>
    `,
    data: function () {
        return {
            capProgSheduleListProg: []
        }
    },
    watch: {
        $route(to, from) {
            if (parseInt(from.params.idCacitacion) !== parseInt(to.params.idCacitacion)) {
                this.onCapProgSheduleListProg();
            }
        }
    },
    async mounted() {
        await this.onCapProgSheduleListProg();
    },
    methods: {
        
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
    },
    {
        path: '/not-found/:message',
        name: 'not-found',
        component: not_found,

    }
]

const router = new VueRouter({
    routes, // short for `routes: routes`
})

const app = new Vue({
    router
}).$mount('#app')