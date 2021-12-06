function DarkUI_exception(message, id_reference = '', isCancelAction = false) {
    this.message = message;
    this.id_reference = id_reference
    this.name = 'DarkUI_exception';
    this.isCancelAction = isCancelAction
}

function diffTime(start, end) {

    start = start.split(":");
    end = end.split(":");
    var startDate = new Date(0, 0, 0, start[0], start[1], 0);
    var endDate = new Date(0, 0, 0, end[0], end[1], 0);
    var diff = endDate.getTime() - startDate.getTime();
    var hours = Math.floor(diff / 1000 / 60 / 60);
    diff -= hours * 1000 * 60 * 60;
    var minutes = Math.floor(diff / 1000 / 60);

    return (hours < 9 ? "0" : "") + hours + ":" + (minutes < 9 ? "0" : "") + minutes;
}
//item-detail-prog
Vue.component('item-detail-prog', {
    props: ['prog', 'idSelected', 'modeView', 'idCapProg'],
    template: `
        <div>
            <router-link
                v-if="modeView === 'link'"
                :to="{ name: 'programar-admin', params: { idCapProg: prog.idCapProg } }"
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
            <div v-if="modeView === 'card' && prog_local !== null" class="d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30">
                <div > 
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb breadcrumb-style1 mg-b-10">
                        </ol>
                    </nav>
                </div>
                <div class="d-none d-md-block">
                    <button v-if="prog_local.estatus === 1 " class="btn btn-sm btn-dark btn-uppercaser" id="btn_programacion_publish" v-on:click="onCapProgSetEstatus(4)">Publicar <i class="typcn typcn-world"></i></button>
                    <button v-if="prog_local.estatus === 2 " class="btn btn-sm btn-danger btn-uppercaser" id="btn_programacion_publish"  v-on:click="onCapProgSetEstatus(2)">Baja<i class="typcn typcn-world"></i></button>
                </div>
            </div>
            <div class="media" v-if="modeView === 'card' && prog_local !== null">
                <div class="wd-45 ht-45 rounded d-flex align-items-center justify-content-center">
                    <span class="tx-color-02"><i class=" typcn typcn-chart-bar-outline tx-40 wd-40 ht-40 stroke-wd-3 mg-b-20"></i></span>
                </div>
                <div class="media-body pd-l-25">
                    <h6 class="tx-color-01 mg-b-5"> {{ prog_local.folio }}</h6>
                    <span class="tx-12 tx-color-03" v-if="prog_local.estatus === 1"> En proceso de diseño </span>
                    <span class="tx-12 tx-color-03" v-if="prog_local.estatus === 2"> Baja </span>
                    <span class="tx-12 tx-color-03" v-if="prog_local.estatus === 3"> Terminada </span>
                    <span class="tx-12 tx-color-03" v-if="prog_local.estatus === 4"> Publicada a participantes </span>
                    <p class="tx-12 mg-b-10" style="margin-bottom: 0px;">{{ prog_local.nombreCap }}</p>
                    <span class="tx-12 tx-color-03" v-if="prog_local.modalidad === 'MIX'"> Mixta </span>
                    <span class="tx-12 tx-color-03" v-if="prog_local.modalidad === 'VIR'"> Virtual </span>
                    <span class="tx-12 tx-color-03" v-if="prog_local.modalidad === 'PRE'"> Presencial  </span>

                    
                </div>
            </div><!-- media -->
        </div>
    `,
    data: function () {
        return {
            info: '',
            prog_local: null
        }
    },
    mounted() {
        if (this.modeView === 'card') {
            this.onCapProgdetails();
        }
    },
    watch: {
        idCapProg: function (newVal, oldVal) { // watch it
            //console.log('Prop changed: ', newVal, ' | was: ', oldVal, '  idCapProg', this.idCapProg)
            if (newVal !== oldVal && this.modeView === 'card') {
                this.onCapProgdetails();
            }
        }
    },
    renderTriggered({ key, target, type }) {
       
    },
    methods: {
        onvalidSms1: function () {
            var alertGl = {
                classs: "",
                message: "",
                publicar: false,
                show: false
            }
            if (this.prog_local !== undefined && this.prog_local !== null) {
                if (this.prog_local.estatus === 4) {
                    alertGl.show = true;
                    alertGl.message = 'Esta evaluacion se encuentra <strong class="tx-uppercase">disponible</strong>, ahora podrás utilizarla en cualquier capacitación, si deseas modificarla por favor crea una versión nueva';
                    alertGl.classs = 'alert alert-success';
                }
                else if (this.prog_local.estatus === 2) {
                    alertGl.show = true;
                    alertGl.message = 'Esta evaluacion ha sido <strong class="tx-uppercase">Inactiva</strong>, ahora no podra ser editada y usada en nuevas capacitacion';
                    alertGl.classs = 'alert alert-info';
                }
                else if (this.prog_local.estatus === 3) {
                    alertGl.show = true;
                    alertGl.message = 'Esta evaluacion ha sido <strong class="tx-uppercase">Eliminada</strong>';
                    alertGl.classs = 'alert alert-warning';
                } else {
                    alertGl.show = true;
                    alertGl.message = 'Esta versión actualmente se encuentra en <strong class="tx-uppercase">proceso de desarrollo</strong> y no podrá ser usada en alguna capacitación, por favor da click en <strong>Publicar esta versión</strong> para que pueda ser usada.';
                    alertGl.classs = 'alert alert-info';
                    alertGl.publicar = true
                }
            }
            return alertGl;
        },
        onCapProgSetEstatus: async function (estatus) {
            btn_loading("btn_programacion_publish", 'Procesando...')
            let formData = new FormData();
            formData.append("IdCapProg", this.idCapProg)
            formData.append("Estatus", estatus)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapProgSetEstatus', formData, null).then(response => {
                this.prog_local.estatus = estatus
                btn_loading("btn_programacion_publish", "Publicar esta capacitación<i class='typcn typcn-world'></i>", 'hide')
                this.$emit("onCapProgDetails", this.prog_local)
            }).catch(error => {
                GlobalValidAxios(error);
                btn_loading("btn_programacion_publish", "Publicar esta capacitación<i class='typcn typcn-world'></i>", 'hide')
            }).finally(() => {

            })
        },
        onCapProgdetails: async function () { 
            await axios.get('../FormacionCapacitacion/CapProgdetails?IdCapProg=' + this.idCapProg, null, null).then(response => {
                this.prog_local = response.data
                this.$emit("onCapProgDetails", response.data)
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
})
//program-add
Vue.component('program-add', {
    props: [],
    template: `
        <div>
            <div class="modal fade" id="modal_pro_add" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered mx-wd-sm-650" role="document">
                    <div class="modal-content bd-0 bg-transparent">
                        <div class="modal-body pd-0">
                            <a href="" role="button" class="close pos-absolute t-15 r-15 z-index-10" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </a>
                            <div class="row no-gutters">
                                <div class="col-3 col-sm-5 col-md-6 col-lg-5 bg-primary rounded-left">
                                    <div class="wd-100p ht-100p">
                                        <img src="https://image.freepik.com/vector-gratis/excelentes-empleados-superando-objetivos-ventas-prometiendo-futuro-prospero_1150-43218.jpg" class="wd-100p img-fit-cover img-object-top rounded-left" alt="" style="object-fit: fill !important;">
                                    </div>
                                </div><!-- col -->
                                <div class="col-9 col-sm-7 col-md-6 col-lg-7 bg-white rounded-right">
                                    <div class="ht-100p d-flex flex-column justify-content-center pd-20 pd-sm-30 pd-md-40">
                                        <span class="tx-color-04"><i data-feather="bar-chart-2" class="wd-40 ht-40 stroke-wd-3 mg-b-20"></i></span>
                                        <h3 class="tx-16 tx-sm-20 tx-md-24 mg-b-15 mg-md-b-20">Nueva programación</h3>
                                        <p class="tx-14 tx-md-16 tx-color-02">Introduce los siguientes datos</p>
                                        <div class="form-group">
                                            <label>Capacitación</label>
                                            <select v-model="idCapTempl" class="w-100 form-control form-control-sm form-control-ds">
                                                <option v-for="option in capTemplVersions" v-bind:value="option.id">
                                                    {{ option.name }}
                                                </option>
                                            </select>
                                        </div>
                                        <div class="form-group" v-if="idCapTempl !== 0 && idCapTempl !== undefined && idCapTempl !== null">
                                            <label>Versión</label>
                                            <select v-model="idversion" class="w-100 form-control form-control-sm form-control-ds">
                                                <option v-for="option in capTemplVersions.find(a => a.id === idCapTempl).versiones" v-bind:value="option.id">
                                                    {{ option.nombre }}
                                                </option>
                                            </select>
                                        </div>
                                        <div class="form-group" v-if="idCapTempl !== 0 && idCapTempl !== undefined && idCapTempl !== null && idversion !== 0 && idversion !== undefined && idversion !== null">
                                            <label>Modalidad</label>
                                            <select v-model="modalidad" class="w-100 form-control form-control-sm form-control-ds">
                                                <option v-for="option in tiposMod" v-bind:value="option.value">
                                                    {{ option.text }}
                                                </option>
                                            </select>
                                        </div>
                                        <button class="btn btn-dark btn-sm btn-block" :disabled="modalidad === ''" v-on:click="onCapProgCreate" id="btn_programa_add">Continuar</button>
                                    </div>
                                </div><!-- col -->
                            </div><!-- row -->
                        </div><!-- modal-body -->
                    </div><!-- modal-content -->
                </div><!-- modal-dialog -->
            </div><!-- modal -->
            
        </div>
    `,
    data: function () {
        return {
            idCapTempl: 0,
            idversion: 0,
            modalidad: '',
            tiposMod: [
                { value: 'PRE', text: 'Presencial' },
                { value: 'VIR', text: 'Virtual' },
                { value: 'MIX', text: 'Mixta' },
            ],
            capTemplVersions: [],
        }
    },
    mounted() {
        this.onCapTemplVersions();
    },
    watch: {
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onCapProgCreate: async function () {
            btn_loading("btn_programa_add", 'Procesando...')
            
            let formData = new FormData();
            formData.append("IdCapTempl", this.idCapTempl)
            formData.append("IdVersion", this.idversion)
            formData.append("Modalidad", this.modalidad)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapProgCreate', formData, null).then(response => {
                
                this.idCapTempl = 0
                this.idversion = 0
                this.modalidad = ''
                btn_loading("btn_programa_add", "Continuar", 'hide')
                $("#modal_pro_add").modal("hide")
                this.$emit("redirect-new", response.data)
            }).catch(error => {
                btn_loading("btn_programa_add", "Continuar", 'hide')
                GlobalValidAxios(error);
            }).finally(() => {
                
            })
        },
        onCapTemplVersions: async function () {
            await axios.get('../FormacionCapacitacion/CapTemplVersions', null, null).then(response => {
                this.capTemplVersions = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
})
//item-prog-details-shedule
Vue.component('item-prog-details-shedule', {
    props: ['idCapProg', 'shedule','modalidad'],
    template: `
        <div>
            <div :class="'timeline-item ' + (shedule.fecha === null ? 'bd-l bd-2 bd-danger': '')">
                <div class="timeline-time tx-danger" v-if="shedule.fecha === null">Sin agendar</div>
                <div class="timeline-time" v-if="shedule.fecha !== null">{{ shedule.fecha | fechaDate }}</div>
                <div class="timeline-body">
                  <h6 class="mg-b-0">{{ shedule.nombreStep }}  {{ modalidad }}</h6>
                  <p style="margin: 0px;" v-if="shedule.tipoShedule === 'SES' && shedule.fecha === null" ><span class="badge badge-danger">Sesión</span></p>
                  <p style="margin: 0px;" v-if="shedule.tipoShedule === 'EVA' && shedule.fecha === null" ><span class="badge badge-primary">Evaluación</span></p>
                    <div class="alert alert-dark" v-if="shedule.fecha !== null" style="padding: 5px 15px;">
                      <p style="margin: 0px;" v-if="shedule.tipoShedule === 'SES'" > <span class="badge badge-danger">Sesión {{ shedule.modalidad === 'MIX' ? 'Mixta' : shedule.modalidad === 'PRE' ? 'Presencial' : 'Virtual' }}</span></p>
                      <p style="margin: 0px;" v-if="shedule.tipoShedule === 'EVA'" ><span class="badge badge-primary">Evaluación {{ shedule.tipoEva === 'DIA' ? 'Diagnostico' : 'Calificacion' }}, {{ shedule.modalidad === 'MIX' ? 'Mixta' : shedule.modalidad === 'PRE' ? 'Presencial' : 'Virtual' }}</span></p>
                      <p style="margin: 0px;" v-if="shedule.fecha !== null && shedule.tipoShedule === 'SES'" v-html="validEvaContraint()"></p>
                      <p style="margin: 0px;" v-if="shedule.fecha !== null && shedule.tipoShedule === 'EVA'" v-html="validEvaContraint()"></p>
                    </div>
                  <nav class="nav nav-row mg-t-15">
                    <a class="nav-link linkds" v-if="shedule.tipoShedule === 'SES' && shedule.fecha === null" v-on:click="beforeCapProgSheduleTimerAdd()" :title="'Agendar esta' + (shedule.tipoShedule === 'SES' ? 'Sesión': 'Evaluación')">Agendar</a>
                    <a class="nav-link linkds" v-if="shedule.tipoShedule === 'SES' && shedule.fecha !== null" v-on:click="beforeCapProgSheduleTimerAdd()" :title="'Re-agendar esta' + (shedule.tipoShedule === 'SES' ? 'Sesión': 'Evaluación')">Re-agendar</a>
                    <a class="nav-link linkds" v-if="shedule.tipoShedule === 'EVA'" v-on:click="beforeCapProgSheduleTimerAdd()" :title="'Configurar esta evaluación'">Config.Evaluación</a>
                  </nav>
                </div><!-- timeline-body -->
            </div><!-- timeline-item -->
            <div class="modal fade" :id="'modal_agendar_shedule_'+shedule.idCapProgShedule" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered mx-wd-sm-650" role="document">
                    <div class="modal-content bd-0 bg-transparent">
                        <div class="modal-body pd-0">
                            <a href="" role="button" class="close pos-absolute t-15 r-15 z-index-10" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </a>
                            <div class="row no-gutters">
                                <div class="col-3 col-sm-5 col-md-6 col-lg-5 bg-primary rounded-left">
                                    <div class="wd-100p ht-100p">
                                        <img src="https://image.freepik.com/vector-gratis/excelentes-empleados-superando-objetivos-ventas-prometiendo-futuro-prospero_1150-43218.jpg" class="wd-100p img-fit-cover img-object-top rounded-left" alt="" style="object-fit: fill !important;">
                                    </div>
                                </div><!-- col -->
                                <div class="col-9 col-sm-7 col-md-6 col-lg-7 bg-white rounded-right">
                                    <div class="ht-100p d-flex flex-column justify-content-center pd-20 pd-sm-30 pd-md-40">
                                        <span class="tx-color-04"><i data-feather="bar-chart-2" class="wd-40 ht-40 stroke-wd-3 mg-b-20"></i></span>
                                        <h3 class="tx-16 tx-sm-20 tx-md-24 mg-b-15 mg-md-b-20" v-if="shedule.tipoShedule === 'SES'">Agendar</h3>
                                        <h3 class="tx-16 tx-sm-20 tx-md-24 mg-b-15 mg-md-b-20" v-if="shedule.tipoShedule === 'EVA'">Configurar evaluación</h3>
                                        <p style="margin: 0px;" v-if="shedule.tipoShedule === 'SES'" >Sesión</p>
                                        <p style="margin: 0px;" v-if="shedule.tipoShedule === 'EVA'" >Evaluación</p>
                                        <h6 class="mg-b-0">{{ shedule.nombreStep }}</h6>
                                        <p class="tx-14 tx-md-16 tx-color-02 mt-3">Introduce los siguientes datos</p>
                                        <div class="mt-1" v-html="resultAddTimer"></div>
                                        <div class="form-group" style="margin-bottom: 5px !important;"  v-if="shedule.tipoShedule === 'EVA'">
                                            <label>Tipo de evaluación</label>
                                            <select v-model="local_shed.tipoEva" class="w-100 form-control form-control-sm form-control-ds">
                                                <option v-for="option in tiposEva" v-bind:value="option.value">
                                                    {{ option.text }}
                                                </option>
                                            </select>
                                        </div>
                                        <div class="form-group" style="margin-bottom: 5px !important;">
                                            <label>Fecha {{ local_shed.fechaFormat }}</label>
                                            <input type="date" v-model="local_shed.fechaFormat" class="form-control" placeholder="Fecha" />
                                        </div>
                                        <div class="form-group" style="margin-bottom: 5px !important;">
                                            <label>Hora de inicio</label>
                                            <input type="time" v-model="local_shed.inicioFormat" class="form-control" placeholder="time" />
                                        </div>
                                        <div class="form-group" style="margin-bottom: 5px !important;">
                                            <label>Hora de fin</label>
                                            <input type="time" v-model="local_shed.finFormat" class="form-control" placeholder="time" />
                                        </div>
                                        <div class="form-group" style="margin-bottom: 5px !important;">
                                            <label>Modalidad</label>
                                            <select v-model="local_shed.modalidad" class="w-100 form-control form-control-sm form-control-ds">
                                                <option v-for="option in getFilterModalidades()" v-bind:value="option.value">
                                                    {{ option.text }}
                                                </option>
                                            </select>
                                        </div>
                                        
                                        <button class="btn btn-dark btn-sm btn-block" :disabled="shedule.tipoShedule === 'EVA' && local_shed.tipoEva === '--'" v-on:click="onCapProgSheduleTimerAdd()" :id="'btn_modal_prog_agendar_'+shedule.idCapProgShedule">Continuar</button>
                                    </div>
                                </div><!-- col -->
                            </div><!-- row -->
                        </div><!-- modal-body -->
                    </div><!-- modal-content -->
                </div><!-- modal-dialog -->
            </div><!-- modal -->
        </div>
    `,
    data: function () {
        return {
            CapProgSheduleListProg: [],
            local_shed: this.shedule,
            tiposMod: [
                { value: 'PRE', text: 'Presencial' },
                { value: 'VIR', text: 'Virtual' },
                { value: 'MIX', text: 'Mixta' },
            ],
            tiposEva: [
                { value: 'DIA', text: 'Diagnostico' },
                { value: 'FIN', text: 'Calificacion' },
            ],
            resultAddTimer: ''
        }
    },
    filters: {
        fechaDate: function (date) {
            moment.locale('es')
            return moment(date).format('MMMM Do YYYY'); // October 25th 2021, 12:30:30 pm
        },
        fechaTime: function (time) {
            return "fecha"
        }
    },
    mounted() {
    },
    watch: {
        idCapProg: function (newVal, oldVal) {
            if (newVal !== oldVal && this.modeView === 'card') {
                console.log("sdfsdfsdfsdf")
            }
        }
    },
    methods: {
        validEvaContraint: function () {
            if (this.local_shed.tipoShedule === 'EVA') {
                //if (this.local_shed.fechaFormat.trim() !== '') {
                //    if (this.local_shed.inicioFormat.trim() !== '' || this.local_shed.finFormat.trim() !== '') {
                //        if (this.local_shed.inicioFormat.trim() !== '' && this.local_shed.finFormat.trim() === '')
                //            return `Disponible a partir del dia: <strong>${this.local_shed.fechaFormat.trim()}</strong> a las <strong>${this.local_shed.inicioFormat.trim()}</strong>`;
                //        else if (this.local_shed.inicioFormat.trim() === '' && this.local_shed.finFormat.trim() !== '')
                //            return `Disponible hasta el dia: <strong>${this.local_shed.fechaFormat.trim()}</strong> a las <strong>${this.local_shed.finFormat.trim()}</strong>`;
                //        else {
                //            return `Disponible hasta el dia: <strong>${this.local_shed.fechaFormat.trim()}</strong> de <strong>${this.local_shed.inicioFormat.trim()}</strong> hasta <strong>${this.local_shed.finFormat.trim()}</strong>`;
                //        }
                //    } else {
                //        return `Disponible en el dia: <strong>${this.local_shed.fechaFormat.trim()}</strong>`
                //    }
                //    //console.log(this.local_shed.fechaFormat)
                //    //console.log(this.local_shed.inicioFormat)
                //    //console.log(this.local_shed.finFormat)
                //} else {
                //    if (this.local_shed.inicioFormat.trim() !== '' && this.local_shed.finFormat.trim() !== '') {
                //        return `Tiempo limite para responder : <strong>${diffTime(this.local_shed.inicioFormat.trim(), this.local_shed.finFormat.trim())} hr(s)</strong>`;
                //    } else {
                //        return "Evaluación libre de reglas, puede ser respondida a cualquier horario"
                //    }
                //}
                return `Horario de <b>${this.local_shed.inicioFormat}</b> a <b>${this.local_shed.finFormat} </b>, Duración: <strong>${this.local_shed.durFormat}</strong> hrs`
            } else {
                return `Horario de <b>${this.local_shed.inicioFormat}</b> a <b>${this.local_shed.finFormat} </b>, Duración: <strong>${this.local_shed.durFormat}</strong> hrs`
            }
            
        },
        getFilterModalidades: function () {
            if (this.modalidad === "MIX") {
                return [
                    { value: 'PRE', text: 'Presencial' },
                    { value: 'VIR', text: 'Virtual' },
                    { value: 'MIX', text: 'Mixta' },
                ]
            } else if (this.modalidad === "VIR") {
                this.local_shed.modalidad = "VIR"
                return [
                    { value: 'VIR', text: 'Virtual' },
                ]
            }
            else if (this.modalidad === "PRE") {
                this.local_shed.modalidad = "PRE"
                return [
                    { value: 'PRE', text: 'Presencial' },
                ]
            } else {
                return []
            }
        },
        onCapProgSheduleTimerAdd: async function () {
            this.resultAddTimer = ''
            btn_loading("btn_modal_prog_agendar_"+this.shedule.idCapProgShedule, 'Procesando...')
            let formData = new FormData();
            formData.append("IdCapProg", this.idCapProg)
            formData.append("IdCapProgShedule", this.shedule.idCapProgShedule)
            formData.append("Fecha", this.local_shed.fechaFormat)
            formData.append("Inicio", this.local_shed.inicioFormat)
            formData.append("Fin", this.local_shed.finFormat)
            formData.append("Modalidad", this.local_shed.modalidad)
            formData.append("TipoEVa", this.local_shed.tipoEva)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapProgSheduleTimerAdd', formData, null).then(response => {
                this.shedule.fecha = response.data.fecha
                this.shedule.inicio = response.data.inicio
                this.shedule.fin = response.data.fin
                this.shedule.modalidad = response.data.modalidad
                this.shedule.inicioFormat = response.data.inicioFormat
                this.shedule.finFormat = response.data.finFormat
                this.shedule.durFormat = response.data.durFormat
                this.shedule.fechaFormat = response.data.fechaFormat
                this.shedule.tipoEva = response.data.tipoEva
                this.resultAddTimer = ''
                btn_loading("btn_modal_prog_agendar_" + this.shedule.idCapProgShedule, "Continuar", 'hide')
                $('#modal_agendar_shedule_' + this.shedule.idCapProgShedule).modal("hide")
            }).catch(error => {
                if (error.response) {
                    this.resultAddTimer = `<div class="alert alert-danger" role="alert"><strong>Info GPS!</strong> ${error.response.data}.</button></div>`
                }
                btn_loading("btn_modal_prog_agendar_" + this.shedule.idCapProgShedule, "Continuar", 'hide')
            }).finally(() => {

            })
        },
        beforeCapProgSheduleTimerAdd: function () {
            this.resultAddTimer = ''
            $('#modal_agendar_shedule_' + this.shedule.idCapProgShedule).modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        }
    }
});
//prog-instructores
Vue.component('prog-instructores', {
    props: ['estatus','idCapProg'],
    template: `
        <div>
            <ul class="list-group list-group-flush tx-13">
                <li class="list-group-item d-flex pd-sm-x-20" v-for="(inst, inst_index) in CapProgInstrByProg" v-bind:key="inst.idCapProgInstr">
                  <div class="pd-l-10">
                    <small class="tx-12 tx-color-03 mg-b-0" v-if="inst.tipo === 'EXT'">EXTERNO</small>
                    <small class="tx-12 tx-color-03 mg-b-0" v-if="inst.tipo === 'INT'">INTERNO</small>
                    <p class="tx-medium mg-b-0">{{ inst.nombre }}</p>
                    <small class="tx-12 tx-color-03 mg-b-0">{{ inst.ocupacion }}</small>
                  </div>
                  <div class="mg-l-auto d-flex align-self-center">
                    <nav class="nav nav-icon-only">
                      <a v-if="estatus === 1" class="nav-link d-none d-sm-block" :title="'Eliminar este instructor: ' + inst.nombre" v-on:click="onCapProgInstrDelete(inst_index)"><i class="tx-danger tx-18 typcn typcn-trash"></i> </a>
                    </nav>
                  </div>
                </li>
            </ul>
            <button v-if="estatus === 1" class="btn btn-block btn-sm btn-danger" title="Agregar nuevo instructor"  v-on:click="beforeCapProgInstrCreate" id="btn_programa_add">Agregar +</button>
            <div class="modal fade" id="modal_pro_add_inst" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered mx-wd-sm-650" role="document">
                    <div class="modal-content bd-0 bg-transparent">
                        <div class="modal-body pd-0">
                            <a href="" role="button" class="close pos-absolute t-15 r-15 z-index-10" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </a>
                            <div class="row no-gutters">
                                <div class="col-3 col-sm-5 col-md-6 col-lg-5 bg-primary rounded-left">
                                    <div class="wd-100p ht-100p">
                                        <img src="https://image.freepik.com/vector-gratis/excelentes-empleados-superando-objetivos-ventas-prometiendo-futuro-prospero_1150-43218.jpg" class="wd-100p img-fit-cover img-object-top rounded-left" alt="" style="object-fit: fill !important;">
                                    </div>
                                </div><!-- col -->
                                <div class="col-9 col-sm-7 col-md-6 col-lg-7 bg-white rounded-right">
                                    <div class="ht-100p d-flex flex-column justify-content-center pd-20 pd-sm-30 pd-md-40">
                                        <span class="tx-color-04"><i data-feather="bar-chart-2" class="wd-40 ht-40 stroke-wd-3 mg-b-20"></i></span>
                                        <h3 class="tx-16 tx-sm-20 tx-md-24 mg-b-15 mg-md-b-20">Nuevo instructor</h3>
                                        <p class="tx-14 tx-md-16 tx-color-02">Introduce los siguientes datos</p>
                                        <div class="form-group">
                                            <label>Tipo</label>
                                            <select v-model="nuevo.tipo" class="w-100 form-control form-control-sm form-control-ds" v-on:change="addSelect2">
                                                <option v-for="option in tiposInstruc" v-bind:value="option.value">
                                                    {{ option.text }}
                                                </option>
                                            </select>
                                        </div>
                                        <div class="form-group" v-if="nuevo.tipo === 'INT'">
                                            <label>Empleado instructor</label>
                                            <select v-model="nuevo.idPersonaIns" class="w-100 form-control form-control-sm form-control-ds" id="select2_add_inst">
                                                <option v-for="option in empleados" v-bind:value="option.idPersona" :disabled="CapProgInstrByProg.find(a => a.idPersona === option.idPersona) != undefined">
                                                    {{ option.nombreCompleto }}
                                                </option>
                                            </select>
                                        </div>
                                        <div class="form-group" v-if="nuevo.tipo === 'EXT'">
                                            <label>Nombre</label>
                                            <input v-model="nuevo.nombre" class="w-100 form-control form-control-sm form-control-ds" placeholder="nombre" />
                                        </div>
                                        <div class="form-group" v-if="nuevo.tipo === 'EXT'">
                                            <label>Ocupacion</label>
                                            <input v-model="nuevo.ocupacion" class="w-100 form-control form-control-sm form-control-ds" placeholder="ocupacion" />
                                        </div>
                                        <button class="btn btn-dark btn-sm btn-block"
                                            :disabled="nuevo.tipo === '' && nuevo.tipo === 'INT' || nuevo.tipo === 'EXT' && nuevo.nombre === '' || nuevo.tipo === 'EXT' && nuevo.ocupacion === ''"
                                            v-on:click="onCapProgInstrCreate()" id="btn_programa_add_insts">Continuar</button>
                                    </div>
                                </div><!-- col -->
                            </div><!-- row -->
                        </div><!-- modal-body -->
                    </div><!-- modal-content -->
                </div><!-- modal-dialog -->
            </div><!-- modal -->
        </div>
    `,
    data: function () {
        return {
            CapProgInstrByProg: [],
            empleados: [],
            nuevo: {
                idPersonaIns: 0,
                tipo: '',
                nombre: '',
                ocupacion: ''
            },
            tiposInstruc: [
                { value: 'EXT', text: 'Externo' },
                { value: 'INT', text: 'Interno' },
            ],
        }
    },
    mounted() {
        this.onCapProgInstrByProg();

        this.onEmpleadoBuscador('')

       
    },
    watch: {
        idCapProg: function (newVal, oldVal) { // watch it
            this.onCapProgInstrByProg();

            
        }
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        addSelect2: function () {
            //$('#select2_add_inst').select2({
            //    placeholder: 'Seleccióna una opción',
            //    searchInputPlaceholder: 'Search options',
            //    dropdownParent: $('#modal_pro_add_inst')
            //});
        },
        onCapProgInstrDelete: async function (index) {
            let formData = new FormData();
            formData.append("IdCapProg", this.CapProgInstrByProg[index].idCapProg)
            formData.append("IdCapProgInstr", this.CapProgInstrByProg[index].idCapProgInstr)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapProgInstrDelete', formData, null).then(response => {
                this.CapProgInstrByProg.splice(index, 1)
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapProgInstrCreate: async function () {
            
            //int IdCapProg, int IdPersonaIns, string Tipo, string Nombre, string Ocupacion
            btn_loading("btn_programa_add_insts", 'Procesando...')

            let formData = new FormData();
            formData.append("IdCapProg", this.idCapProg)
            formData.append("IdPersonaIns", this.nuevo.idPersonaIns)
            formData.append("Tipo", this.nuevo.tipo)
            formData.append("Nombre", this.nuevo.nombre)
            formData.append("Ocupacion", this.nuevo.ocupacion)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapProgInstrCreate', formData, null).then(response => {
                this.CapProgInstrByProg.push(response.data);
                this.nuevo = {
                    idPersonaIns: 0,
                    tipo: '',
                    nombre: '',
                    ocupacion: ''
                },
                btn_loading("btn_programa_add_insts", "Agregar +", 'hide')
                $("#modal_pro_add_inst").modal("hide")
            }).catch(error => {
                btn_loading("btn_programa_add_insts", "Agregar +", 'hide')
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        beforeCapProgInstrCreate: function () {
            $("#modal_pro_add_inst").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onCapProgInstrByProg: async function () {
            await axios.get('../FormacionCapacitacion/CapProgInstrByProg?IdCapProg=' + this.idCapProg, null, null).then(response => {
                
                this.CapProgInstrByProg = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onEmpleadoBuscador: async function (patron) {
            await axios.get('../Empleado/Buscador?patron=' + patron, null, null).then(response => {
                this.empleados = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
})
//prog-participantes
Vue.component('prog-participantes', {
    props: ['estatus', 'idCapProg'],
    template: `
        <div>
            <div class="card mg-b-20 mg-lg-b-5" >
                <div class="card-header pd-t-20 d-sm-flex align-items-start justify-content-between bd-b-0 pd-b-0">
                    <div>
                      <h6 class="mg-b-5">Participantes</h6>
                    </div>
                    <div class="d-flex mg-t-20 mg-sm-t-0">
                      <div class="btn-group flex-fill">
                        <button v-if="estatus === 1" class="btn btn-white btn-xs active" v-on:click="beforeCapKardexCreate()">Agregar nuevo</button>
                      </div>
                    </div>
                </div><!-- card-header -->
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table table-dashboard mg-b-0">
                          <thead>
                            <tr>
                              <th>Empleado</th>
                              <th class="">Puesto</th>
                              <th class="text-right">Cal.Diag</th>
                              <th class="text-right">Cal.Final</th>
                              <th class="text-right"></th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr v-for="(emp, emp_index) in CapKardexDetails">
                              <td class="tx-color-03 tx-normal">{{ emp.nombre }}</td>
                              <td class="tx-color-03 tx-normal">{{ emp.puesto }}</td>
                              <td class="tx-color-03 tx-normal">{{ emp.calInicial }}</td>
                              <td class="tx-color-03 tx-normal">{{ emp.calFinal }}</td>
                              <td class="tx-color-03 tx-normal">
                                <a class="" v-if="estatus === 1" :title="'Eliminar este participante: ' + emp.nombre" v-on:click="onCapKardexDelete(emp_index)"><i class="tx-danger tx-18 typcn typcn-trash"></i> </a>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                    </div><!-- table-responsive -->
                </div>
                <!-- card-body -->
            </div>
            <!-- card -->
            <div class="modal fade" id="modal_pro_add_emp" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered mx-wd-sm-650" role="document">
                    <div class="modal-content bd-0 bg-transparent">
                        <div class="modal-body pd-0">
                            <a href="" role="button" class="close pos-absolute t-15 r-15 z-index-10" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </a>
                            <div class="row no-gutters">
                                <div class="col-3 col-sm-5 col-md-6 col-lg-5 bg-primary rounded-left">
                                    <div class="wd-100p ht-100p">
                                        <img src="https://image.freepik.com/vector-gratis/excelentes-empleados-superando-objetivos-ventas-prometiendo-futuro-prospero_1150-43218.jpg" class="wd-100p img-fit-cover img-object-top rounded-left" alt="" style="object-fit: fill !important;">
                                    </div>
                                </div><!-- col -->
                                <div class="col-9 col-sm-7 col-md-6 col-lg-7 bg-white rounded-right">
                                    <div class="ht-100p d-flex flex-column justify-content-center pd-20 pd-sm-30 pd-md-40">
                                        <span class="tx-color-04"><i data-feather="bar-chart-2" class="wd-40 ht-40 stroke-wd-3 mg-b-20"></i></span>
                                        <h3 class="tx-16 tx-sm-20 tx-md-24 mg-b-15 mg-md-b-20">Nuevo participante</h3>
                                        <p class="tx-14 tx-md-16 tx-color-02">Introduce los siguientes datos</p>
                                        <div class="form-group" >
                                            <label>Empleado</label>
                                            <select v-model="idPersona" class="w-100 form-control form-control-sm form-control-ds" id="select2_add_partici">
                                                <option v-for="option in empleados" v-bind:value="option.idPersona" :disabled="CapKardexDetails.find(a => a.idPersona === option.idPersona) !== undefined">
                                                    {{ option.nombreCompleto }}
                                                </option>
                                            </select>
                                        </div>
                                        
                                        <button class="btn btn-dark btn-sm btn-block"
                                            :disabled="idPersona === 0"  v-on:click="onCapKardexCreate()" id="btn_programa_add_emp">Agregar +</button>
                                    </div>
                                </div><!-- col -->
                            </div><!-- row -->
                        </div><!-- modal-body -->
                    </div><!-- modal-content -->
                </div><!-- modal-dialog -->
            </div><!-- modal -->
        </div>
    `,
    data: function () {
        return {
            CapKardexDetails: [],
            empleados: [],
            idPersona: 0
        }
    },
    mounted() {
        this.onCapKardexDetailsProg()
        this.onEmpleadoBuscador('')
        
    },
    watch: {
        idCapProg: function (newVal, oldVal) { // watch it
            this.onCapKardexDetailsProg()
        }
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onCapKardexDelete: async function (index) {

            let formData = new FormData();
            formData.append("IdCapProg", this.idCapProg)
            formData.append("IdPersonaPart", this.CapKardexDetails[index].idPersona)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapKardexDelete', formData, null).then(response => {
                this.CapKardexDetails.splice(index, 1);
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapKardexCreate: async function () {

            //int IdCapProg, int IdPersonaIns, string Tipo, string Nombre, string Ocupacion
            btn_loading("btn_programa_add_emp", 'Procesando...')

            let formData = new FormData();
            formData.append("IdCapProg", this.idCapProg)
            formData.append("IdPersonaPart", this.idPersona)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapKardexCreate', formData, null).then(response => {
                this.CapKardexDetails.push(response.data);
                this.idPersona = 0
                btn_loading("btn_programa_add_emp", "Agregar +", 'hide')
                $("#modal_pro_add_emp").modal("hide")
            }).catch(error => {
                btn_loading("btn_programa_add_emp", "Agregar +", 'hide')
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        beforeCapKardexCreate: function () {
            $("#modal_pro_add_emp").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onCapKardexDetailsProg: async function (patron) {
            await axios.get('../FormacionCapacitacion/CapKardexDetailsProg?IdCapProg=' + this.idCapProg, null, null).then(response => {
                this.CapKardexDetails = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onEmpleadoBuscador: async function (patron) {
            await axios.get('../Empleado/Buscador?patron=' + patron, null, null).then(response => {
                this.empleados = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
})

const Programar = {
    template: `
        <div>
            <div class="row">
                <div class="col-3">
                    <div class="card mg-b-20 mg-lg-b-5">
                        <div class="card-body">
                            <button class="btn btn-sm btn-block btn-dark" v-on:click="beforeCapProgCreate()">Agregar <i class="typcn typcn-plus"></i></button>
                            <div class="schedule-group mt-2">
                                <item-detail-prog v-for="(prog, prog_index) in capCapProgList" v-bind:key="prog.idCapProg" v-bind:idCapProg="prog.idCapProg" v-bind:prog="prog" v-bind:idSelected="$route.params.idCapProg" modeView='link'></item-detail-prog>
                            </div>
                            <!-- schedule-group -->
                        </div>
                        <!-- card-body -->
                    </div>
                    <!-- card -->
                </div>
                 <!-- col -->
                <div class="col-9">
                    <router-view v-if="$route.params.idCapProg !== undefined && $route.params.idCapProg !== null && $route.params.idCapProg !== 0" ></router-view>
                    
                </div><!-- col -->
            </div>

            <program-add v-on:redirect-new="onCapProgCreate"></program-add>
            
        </div>
    `,
    data: function () {
        return {
            capCapProgList: [],
        }
    },
    watch: {
        $route(to, from) {

        }
    },
    mounted() {
        this.onCapCapProgList();
    },
    methods: {
        onCapProgCreate: function (newProg) {
            this.capCapProgList.push(newProg)
            router.push({ name: 'programar-admin', params: { idCapProg: newProg.idCapProg } })
        },
        beforeCapProgCreate: function () {
            $("#modal_pro_add").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onCapCapProgList: async function () {
            //let formData = new FormData();
            //formData.append("IdCapEva", this.$route.params.idCapEva)
            //formData.append("IdCapEvaPrg", this.$route.params.idCapEvaPrg)
            await axios.get('../FormacionCapacitacion/CapCapProgList', null, null).then(response => {
                this.capCapProgList = response.data
               
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
    }
}

const Programar_admin = {
    template: `
        <div>
            <div class="row">
                <div class="col-8">
                    <div class="card mg-b-20 mg-lg-b-5">
                        <div class="card-body">
                            <item-detail-prog v-bind:idCapProg="$route.params.idCapProg" modeView='card' v-on:onCapProgDetails="onCapProgDetails"></item-detail-prog>
                            <div class="timeline-group tx-13" v-if="CapProg !== null && CapProg !== undefined">
                                <div class="timeline-label">AGENDA</div>
                                <item-prog-details-shedule v-for="(shedule, sheduleIndex) in CapProgSheduleListProg " v-bind:key="shedule.idCapProgShedule" v-bind:shedule="shedule" v-bind:idCapProg="$route.params.idCapProg" v-bind:modalidad="CapProg.modalidad"> </item-prog-details-shedule>
                            </div>
                        </div>
                        <!-- card-body -->
                    </div>
                    <prog-participantes  v-if="CapProg !== null && CapProg !== undefined" v-bind:idCapProg="$route.params.idCapProg" v-bind:estatus="CapProg.estatus"> </prog-participantes>
                    <!-- card -->
                </div><!-- col -->
                <div class="col-4">
                    <div class="card mg-b-20 mg-lg-b-5" v-if="CapProg !== null && CapProg !== undefined">
                        <div class="card-header pd-t-20 d-sm-flex align-items-start justify-content-between bd-b-0 pd-b-0">
                            <div>
                              <h6 class="mg-b-5">Instructores</h6>
                            </div>
                        </div><!-- card-header -->
                        <div class="card-body">
                            <prog-instructores v-bind:idCapProg="$route.params.idCapProg" v-bind:estatus="CapProg.estatus"></prog-instructores>
                        </div>
                        <!-- card-body -->
                    </div>
                </div><!-- col -->
            </div><!-- row -->
        </div>
    `,
    data: function () {
        return {
            CapProgSheduleListProg: [],
            CapProg : null
        }
    },
    watch: {
        $route(to, from) {
            if (to.params.idCapProg !== from.params.idCapProg) {
                this.onCapProgSheduleListProg()
            }
        }
    },
    mounted() {
        this.onCapProgSheduleListProg()
    },
    methods: {
        
        onCapProgDetails: function (details) {
            this.CapProg = details
        },
        onCapProgSheduleListProg: async function () {
            //
            await axios.get('../FormacionCapacitacion/CapProgSheduleListProg?IdCapProg=' + this.$route.params.idCapProg, null, null).then(response => {
                this.CapProgSheduleListProg = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
}

const routes = [
    {
        path: '/',
        component: Programar,
        children: [
            {
                name: 'programar-admin',
                path: 'programa/:idCapProg',
                component: Programar_admin
            }
        ]
    },
]

const router = new VueRouter({
    routes, // short for `routes: routes`
})

const app = new Vue({
    router
}).$mount('#app')