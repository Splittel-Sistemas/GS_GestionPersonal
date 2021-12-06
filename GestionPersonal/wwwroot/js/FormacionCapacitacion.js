function DarkUI_exception(message, id_reference = '', isCancelAction = false) {
    this.message = message;
    this.id_reference = id_reference
    this.name = 'DarkUI_exception';
    this.isCancelAction = isCancelAction
}

Vue.directive('click-outside', {
    bind: function (el, binding, vnode) {
        this.event = function (event) {
            if (!(el === event.target || el.contains(event.target))) {
                vnode.context[binding.expression](event);
            }
        };
        document.body.addEventListener('click', this.event)
    },
    unbind: function (el) {
        document.body.removeEventListener('click', this.event)
    },
});
const EvaList = {
    template: `
        <div>
            <div class="d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30">
                <div>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb breadcrumb-style1 mg-b-10">
                            <li class="breadcrumb-item active" aria-current="page">Evaluaciones</li>
                        </ol>
                    </nav>
                    <h4 class="mg-b-0 tx-spacing--1">Evaluaciones</h4>
                </div>
            </div>
            <div class="content content-fixed content-auth-alt mt-5 row" v-if="evaList.length === 0">
                <div class="container ht-100p tx-center mt-5">
                    <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                        <div class="wd-70p wd-sm-250 wd-lg-300 mg-b-15"><img src="https://image.freepik.com/vector-gratis/empleador-que-reune-al-solicitante-empleo-evaluacion-previa-al-empleo-evaluacion-empleados-formulario-e-informe-evaluacion-ilustracion-concepto-revision-desempeno_335657-2058.jpg" class="img-fluid" alt=""></div>
                        <h2 class="tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5">Sin evaluaciones</h2>
                        <h5 class="tx-16 tx-sm-18 tx-lg-20 tx-normal mg-b-20">No se encontrarón evaluaciones, por favor crea una para continuar</h5>
                        <div class="mg-b-40">
                            <button class="btn btn-white bd-2 pd-x-30" v-on:click="onBeforeCapEvaAdd()">Crear mi primer evaluación</button>
                        </div>
                    </div>
                </div><!-- container -->
            </div><!-- content -->
            <div class="row"  v-if="evaList.length > 0">
                <div class="col-3">
                    <div class="card">
                        <div class="card-body row">
                            <button class="btn btn-sm btn-dark btn-block" v-on:click="onBeforeCapEvaAdd()">Nueva evaluación</button>
                            <div class="col-12 mt-3">
                                <div class="schedule-group">
                                    <router-link
                                        v-for="(eva_, eva_index) in evaList"
                                        :to="{ name: 'evaluacion-details', params: { idCapEva: eva_.idCapEva } }"
                                        :title="'click aqui para editar el tema: ' + eva_.nombre"
                                        :class="'schedule-item bd-l bd-2 ' + ( $route.params.idCapEva+'' === eva_.idCapEva+'' ? 'bd-warning active-tema' : 'bd-primary' )"
                                    >
                                        <h6> {{ eva_.nombre }}</h6>
                                        <span>{{ eva_.decripcion }}</span>
                                    </router-link>
                                </div><!-- schedule-group -->
                            </div><!-- col -->
                        </div><!-- card-body -->
                    </div><!-- card -->
                </div><!-- col -->
                <div class="col-9">
                    <transition name="fade" mode="out-in">
                        <router-view></router-view>
                    </transition>
                </div><!-- col -->
            </div><!-- row -->
            <div class="modal fade" id="modal_register_eva" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                                          <h3 class="tx-16 tx-sm-20 tx-md-24 mg-b-15 mg-md-b-20">Nueva evaluación</h3>
                                          <p class="tx-14 tx-md-16 tx-color-02">Introduce los siguientes datos para diseñar una nueva evaluación</p>
                                          <div class="form-group">
                                            <label>Nombre</label>
                                            <input type="text" class="form-control" placeholder="Nombre" v-model="capEva.nombre">
                                        </div>
                                        <button class="btn btn-dark btn-sm btn-block" :disabled="capEva.nombre === ''" v-on:click="onCapEvaAdd()" id="btn_add_eva">Continuar</button>
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
            error_DarkUI_exception: null,
            evaList: [],
            capEva: {
                nombre: ''
            },
            selectedEva: null
        }
    },
    watch: {
        $route(to, from) {
            console.log('mounted EvaList wach')
        }
    },
    mounted() {
        this.getList();
        //console.log(this.$route.name)
        //router.push({ path: '/Evaluaciones/Detalle/0' })
    },
    methods: {
        onCapEvaAdd: async function () {

            btn_loading('btn_add_eva', 'Guardando...')
            let formData = new FormData();
            formData.append("Nombre", this.capEva.nombre)
            formData.append("Instruccionesa", 'N/A')
            await axios.post('../FormacionCapacitacion/CapEvaAdd', formData, null).then(async (response) => {
                await btn_loading('btn_add_eva', 'Guardar', 'hide')
                $("#modal_register_eva").modal('hide')
                this.evaList.push(response.data)
                this.capEva.nombre = ''
                router.push({ name: 'evaluacion-details', params: { idCapEva: response.data.idCapEva } })

            }).catch(error => {
                btn_loading('btn_add_eva', 'Guardar', 'hide')

                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onBeforeCapEvaAdd: function () {
            $("#modal_register_eva").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        toToDetails: function (eva_index) {
            //'../Detalle/' + eva_.idCapEva
            this.selectedEva = eva_index
            router.push({ name: 'evaluacion-details', params: { idCapEva: this.evaList[eva_index].idCapEva } })
        },
        getList: async function () {
            await axios.get('../FormacionCapacitacion/CapEvaList', null, null).then(response => {
                this.evaList = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
}

const EvaDetails = {
    template: `
        <div>
            <div class="row"  v-if="$route.params.idCapRegistryVersion === undefined || $route.params.idCapRegistryVersion === null">
                <h2 class="col-lg-12">Selecciona una versión</h2>
				<!--begin::Col-->
				<div class="col-lg-4 alert alert-success  ml-1 mr-1" role="alert" v-for="(log, log_index) in logChangesStatus">
					<router-link
                            :to="{ name: 'evaluacion-preguntas', params: { idCapRegistryVersion: log.idCapRegistryVersion } }"
                            :title="'click aqui para ver version'"
                            :id="'ver_version_ev_det_' + log.idCapRegistryVersion"
                            :class="'schedule-item'"
                        >
                            <h6 >{{ log.comentarios }}</h6>
                            <span class="tx-13 tx-color-03"> {{ log.editada | fechaDate }}</span>
                            <span class="tx-13 tx-color-03"> {{ log.nombre }}</span>
                        </router-link>
				</div>
                <!--end::Col-->
            </div>
            <div class="row" v-if="capEva != null">
                <div class="col-8">
                    <div v-if="logChangesStatus.length && onvalidSms1().show" :class="onvalidSms1().classs" role="alert">
                            <h4 class="alert-heading">Estimado usuario!</h4>
                            <p v-html="onvalidSms1().message"></p>
                            <button type="button" v-if="onvalidSms1().publicar" class="btn btn-sm btn-block btn-dark"  title="publicar" v-on:click="onCapVersionSetActive(4)" id="btn_eva_version_publish">Publicar esta versión<i class="typcn typcn-world"></i></button>
                    </div>
                    <div class="d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30" v-if="version !== undefined && version !== null && $route.params.idCapRegistryVersion !== undefined && $route.params.idCapRegistryVersion !== null">
                        <div>
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb breadcrumb-style1 mg-b-10">
                                </ol>
                            </nav>
                            <h4 class="mg-b-0 tx-spacing--1">Version: {{ version.comentarios }}</h4>
                        </div>
                        <div class="d-none d-md-block">
                            <button class="btn btn-sm pd-x-15 btn-dark btn-uppercase mg-l-5" v-on:click="onBeforeCapEvaChangeStatus()" title="crear nueva versión"><i class="typcn typcn-document-text"></i> Crear nueva versión</button>
                        </div>
                    </div>
                    <div class="card mg-b-20 mg-lg-b-5"  v-if="$route.params.idCapRegistryVersion !== undefined">
                        <div class="card-header pd-t-20 d-sm-flex align-items-start justify-content-between bd-b-0 pd-b-0">
                            <div>
                                <h5 class="mg-b-5">Detalle de la evaluacion</h5>
                                <p class="tx-13 tx-color-03 mg-b-0"></p>
                            </div>
                            <div class="d-flex mg-t-20 mg-sm-t-0">
                                <div class="btn-group flex-fill">
                                    <a class=" float-right tx-warning" v-if="view.editEva === false && capEva !== null && capEva.estatus === 1" v-on:click="onEditEva(true)" title="Editar evaluacion"><i class="typcn typcn-pencil"></i></a>
                                    <a class=" float-right tx-warning" v-if="view.editEva === true && capEva !== null && capEva.estatus === 1" v-on:click="onEditEva(false)" title="Cerrar formulario"><i class="typcn typcn-times"></i></a>
                                </div>
                            </div>
                        </div><!-- card-header -->
                        <div class="card-body pd-l-25 pd-r-25">
                            
                            <dl class="row" style="font-size: 13px;" v-if="view.editEva === false">
                                <dt class="col-12">
                                    Nombre
                                </dt>
                                <dd class="col-12">
                                    {{ capEva.nombre }}
                                </dd>
                                <dt class="col-12">
                                    Descripcion
                                </dt>
                                <dd class="col-12">
                                    {{ capEva.decripcion }}
                                </dd>
                            </dl>
                            
                            <div class="col-12" v-if="view.editEva === true">
                                <div class="form-group mt-2" style="margin-bottom: 1px !important">
                                    <label for="" class="">Nombre </label>
                                    <input type="text" class="form-control form-control-sm" maxLength="100" v-model="capEvaDe.nombre" placeholder="Nombre de la sesión">
                                </div><!-- form-group -->
                                <div class="form-group mt-2" style="margin-bottom: 1px !important">
                                    <label for="" class="">Descripcion </label>
                                    <textarea  class="form-control form-control-sm" maxLength="300" v-model="capEvaDe.decripcion" placeholder="Objetivo" rows="3"></textarea>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (300 - capEvaDe.decripcion.length) + ' / 300' }}</span>
                                </div><!-- form-group -->
                                <div class="form-group row mg-b-0 mt-4">
                                    <div class="col-sm-12 text-right">
                                        <button type="button" class="btn btn-sm btn-dark" title="Guardar evaluacion" v-if="capEva.nombre !== ''" v-on:click="onCapEvaEit()" id="btn_upd_eva">Actualizar <i class="typcn typcn-arrow-sync"></i></button>
                                    </div>
                                </div><!-- form-group -->
                            </div><!-- col 12 -->
                        </div><!-- card-body -->
                    </div><!-- card -->
                    <div class="card" v-if="$route.name === 'evaluacion-preguntas'">
                        <div class="card-header pd-t-20 d-sm-flex align-items-start justify-content-between bd-b-0 pd-b-0">
                            <div>
                                <h5 class="mg-b-5">Reactivos</h5>
                                <p class="tx-13 tx-color-03 mg-b-0"></p>
                            </div>
                            <div class="d-flex mg-t-20 mg-sm-t-0">
                                <div class="btn-group flex-fill">
                                </div>
                            </div>
                        </div><!-- card-header -->
                        <div class="card-body row">
                            <router-view class="col-12"></router-view>
                        </div><!-- card-body -->
                    </div><!-- card -->
                    <router-view class="col-12" :key="$route.fullPath" v-if="$route.name !== 'evaluacion-preguntas'"></router-view>
                    <button class="btn btn-block btn-sm pd-x-15 btn-danger btn-uppercase mg-l-5 mt-3" v-if="capEva !== null && capEva.estatus === 4 && $route.params.idCapRegistryVersion !== undefined" v-on:click="onCapVersionSetActive(2)" id="btn_eva_version_deactive" title="Desactivar esta versión"><i class="typcn typcn-document-text"></i> Desactivar esta versión</button>
                </div><!-- col -->
                <div class="col-4" v-if="$route.params.idCapRegistryVersion !== undefined && $route.params.idCapRegistryVersion !== null">
                    <div class="d-flex align-items-center justify-content-between mg-b-20">
                        <h6 class="tx-uppercase tx-semibold mg-b-0">Versiones</h6>
                    </div>
                    <div class="schedule-group">
                        <router-link
                            v-for="(log, log_index) in logChangesStatus"
                            :to="{ name: 'evaluacion-preguntas', params: { idCapRegistryVersion: log.idCapRegistryVersion } }"
                            :title="'click aqui para ver version'"
                            :id="'ver_version_ev_det_' + log.idCapRegistryVersion"
                            :class="'schedule-item bd-l bd-2 ' + ( $route.params.idCapRegistryVersion+'' === log.idCapRegistryVersion+'' ? 'bd-warning active-tema' : 'bd-danger' )"
                        >
                            <h6 >{{ log.comentarios }}</h6>
                            <span class="tx-13 tx-color-03"> {{ log.editada | fechaDate }}</span>
                            <span class="tx-13 tx-color-03"> {{ log.nombre }}</span>
                        </router-link>
                    </div><!-- schedule-group -->
                </div><!-- col -->
            </div><!-- row -->
            
            <div class="modal fade" id="modal_add_eva_version" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                                          <h3 class="tx-16 tx-sm-20 tx-md-24 mg-b-15 mg-md-b-20">Crear nueva versión</h3>
                                          <p class="tx-14 tx-md-16 tx-color-02">Introduce los siguientes datos para continuar..</p>
                                         <div class="form-group">
                                            <label>Comentarios</label>
                                            <textarea class="form-control" rows="2" placeholder="Comentarios" v-model="comentarios"></textarea>
                                        </div>
                                        <button class="btn btn-dark btn-sm btn-block" :disabled="comentarios === ''" v-on:click="onCapEvaChangeStatus(1)" id="btn_add_eva_version">Crear</button>
                                    </div>
                                </div><!-- col -->
                            </div><!-- row -->
                        </div><!-- modal-body -->
                    </div><!-- modal-content -->
                </div><!-- modal-dialog -->
            </div><!-- modal -->
            <button v-on:click="getCapEvaDetails()" style="display:none" id="bt_eva_refres_version">refresh detailseva</button>
        </div>`,
    data: function () {
        //
        return {
            error_DarkUI_exception: null,
            capEva: null,
            capEvaDe: null,
            versionSelected: null,
            logChangesStatus: [],
            view: {
                editEva: false,
                editIdCapEvaPrg: 0,

            },
            comentarios: "",
            version: null
        }
    },
    watch: {
        $route(to, from) {
            //if (to.path !== to.path) {
            if (this.$route.params.idCapEva !== 0 && this.$route.params.idCapEva !== '0' && this.$route.params.idCapRegistryVersion !== undefined && this.$route.params.idCapRegistryVersion !== null) {
                this.getCapEvaDetails();
                this.capEva = null
                this.version = null
                this.versionSelected = null
                this.comentarios = ''
            }
            //}
            this.onCapRegistrtList();
        }
    },
    mounted() {
        if (this.$route.params.idCapEva !== 0 && this.$route.params.idCapEva !== '0' && this.$route.params.idCapRegistryVersion !== undefined && this.$route.params.idCapRegistryVersion !== null) {
            this.getCapEvaDetails();
        }
        this.onCapRegistrtList();
    },
    filters: {
        fechaDate: function (date) {
            return moment(date).format('MMMM Do YYYY, h:mm:ss a'); // October 25th 2021, 12:30:30 pm
        }
    },
    methods: {
        onvalidSms1: function () {
            var alertGl = {
                classs: "",
                message: "",
                publicar: false,
                show: false
            }
            if (this.$route.params.idCapRegistryVersion === undefined || this.$route.params.idCapRegistryVersion === null) {
                alertGl.show = false;
                alertGl.message = 'Por favor selecciona una versión para poder administrar';
                alertGl.classs = 'alert alert-info';
            } else {
                if (this.capEva !== undefined && this.capEva !== null) {
                    if (this.capEva.estatus === 4) {
                        alertGl.show = true;
                        alertGl.message = 'Esta evaluacion se encuentra <strong class="tx-uppercase">disponible</strong>, ahora podrás utilizarla en cualquier capacitación, si deseas modificarla por favor crea una versión nueva';
                        alertGl.classs = 'alert alert-success';
                    }
                    else if (this.capEva.estatus === 2) {
                        alertGl.show = true;
                        alertGl.message = 'Esta evaluacion ha sido <strong class="tx-uppercase">Inactiva</strong>, ahora no podra ser editada y usada en nuevas capacitacion';
                        alertGl.classs = 'alert alert-info';
                    }
                    else if (this.capEva.estatus === 3) {
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
            }
            //{ { $route.params.idCapRegistryVersion } }
            //{ {  } }
            //{ { logChangesStatus.find(a => a.idCapRegistryVersion === $route.params.idCapRegistryVersion).actual } }
            return alertGl;
        },
        onCapVersionSetActive: async function (estatus) {
            var title = ""
            var text = ""
            var btn_id = ""
            var btn_idAction = ""
            if (estatus === 4) {
                title = "¿Deseas publicar esta versión?"
                text = "despues de publicar podrá ser usada esta versión"
                btn_id = "btn_eva_version_publish"
                btn_idAction = "Publicar"
            } else if (estatus === 2) {
                title = "¿Deseas desactivar esta versión?"
                text = "despues de desactivar no podrá ser usada y modificada esta versión"
                btn_id = "btn_eva_version_deactive"
                btn_idAction = "Desactivar"
            }

            try {
                await Swal.fire({
                    title: title,
                    text: text,
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Si, adelante!'
                }).then(async (result) => {
                    if (!result.isConfirmed) {
                        throw new DarkUI_exception('proceso cancelado', '', true);
                    }
                })

                btn_loading(btn_id, 'Procesando...')
                let formData = new FormData();
                formData.append("IdCapEva", this.$route.params.idCapEva)
                formData.append("IdVersion", this.$route.params.idCapRegistryVersion)
                formData.append("Estatus", estatus)

                await axios.post('../FormacionCapacitacion/CapEvaSetEstatus', formData, null).then(response => {
                    // agregar la pregunta a la lista
                    this.capEva.estatus = estatus
                    window.location.reload()
                    btn_loading(btn_id, btn_idAction, 'hide')
                }).catch(error => {
                    GlobalValidAxios(error);
                    btn_loading(btn_id, btn_idAction, 'hide')
                }).finally(() => {
                    this.onCapRegistrtList();

                })


            } catch (e) {
                console.log(e)
            }
        },
        onCapEvaChangeStatus: async function (Status_) {
            btn_loading('btn_add_eva_version', 'Guardando...')
            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("IdVersion", this.$route.params.idCapRegistryVersion)
            formData.append("Status_", Status_)
            formData.append("Comentarios", this.comentarios)

            await axios.post('../FormacionCapacitacion/CapEvaRegistryVersion', formData, null).then(async (response) => {
                // agregar la pregunta a la lista
                await this.logChangesStatus.push(response.data)
                //document.getElementById("btn_preg_list_refresh").click()
                btn_loading('btn_add_eva_version', 'Guardar', 'hide')

                $("#modal_add_eva_version").modal("hide")
                this.comentarios = ""
                document.getElementById("ver_version_ev_det_" + response.data.idCapRegistryVersion).click()
            }).catch(error => {
                GlobalValidAxios(error);
                btn_loading('btn_add_eva_version', 'Guardar', 'hide')
            }).finally(() => {
                this.onCapRegistrtList();

            })
        },
        onBeforeCapEvaChangeStatus: function () {
            $("#modal_add_eva_version").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onCapRegistrtList: async function () {
            await axios.get('../FormacionCapacitacion/CapVersionList?TipoRef_=EVA&IdRefer_=' + this.$route.params.idCapEva, null, null).then(response => {
                this.logChangesStatus = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapEvaEit: async function () {

            btn_loading('btn_upd_eva', 'Guardando...')

            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("Nombre", this.capEvaDe.nombre)
            formData.append("Instruccionesa", this.capEvaDe.decripcion)
            formData.append("IdVersion", this.$route.params.idCapRegistryVersion)

            await axios.post('../FormacionCapacitacion/CapEvaEit', formData, null).then(response => {
                // agregar la pregunta a la lista
                this.capEva = JSON.parse(JSON.stringify(this.capEvaDe))
                /*this.capEva_obj.capEvaPrg_list.push(response.data);*/
                btn_loading('btn_upd_eva', 'Actualizar <i class="typcn typcn-arrow-sync"></i>', 'hide')
                this.view.editEva = false
            }).catch(error => {
                GlobalValidAxios(error);
                btn_loading('btn_upd_eva', 'Actualizar <i class="typcn typcn-arrow-sync"></i>', 'hide')
            }).finally(() => {
            })
        },
        onEditEva: function (status) {
            this.view.editEva = status
            this.capEvaDe = JSON.parse(JSON.stringify(this.capEva))
        },
        setCapEvaPrgSelected: function (preg_index) {
            this.capEvaPrgSelected = preg_index
        },
        getCapEvaDetails: async function () {
            await axios.get('../FormacionCapacitacion/CapEvaDetails?IdVersion=' + this.$route.params.idCapRegistryVersion + '&IdCapEva=' + this.$route.params.idCapEva, null, null).then(response => {
                this.capEva = response.data.eva
                this.version = response.data.version
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
}

const EvaDetailsList = {
    template: `
        <div>
            <button type="button" class="btn btn-sm btn-block btn-dark"  v-on:click="onCapEvaDetails()" id="btn_preg_list_refresh" style="display:none"><i class="typcn typcn-document-plus"></i>Regrescar</button>
             <div class="content content-fixed content-auth-alt mt-5 row" v-if="capEvaPrgList.length === 0">
                <div class="container ht-100p tx-center mt-5">
                    <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                        <div class="wd-70p wd-sm-250 wd-lg-300 mg-b-15"><img src="https://image.freepik.com/vector-gratis/empleador-que-reune-al-solicitante-empleo-evaluacion-previa-al-empleo-evaluacion-empleados-formulario-e-informe-evaluacion-ilustracion-concepto-revision-desempeno_335657-2058.jpg" class="img-fluid" alt=""></div>
                        <h2 class="tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5">Sin preguntas</h2>
                        <h5 class="tx-16 tx-sm-18 tx-lg-20 tx-normal mg-b-20">No se encontrarón preguntas, por favor crea una para continuar</h5>
                        <div class="mg-b-40">
                            <button class="btn btn-white bd-2 pd-x-30" v-on:click="onCapEvaPrgAdd()" id="btn_add_preg_ed_1">Crear primer pregunta</button>
                        </div>
                    </div>
                </div><!-- container -->
            </div><!-- content -->
            <div class="schedule-group w-100 mt-1 mb-4" v-if="capEvaPrgList.length > 0">
                <div v-for="(preg, preg_index) in capEvaPrgList"
                    :class="'schedule-item bd-l bd-2 ' + (capEvaPrgSelected !== null && capEvaPrgSelected.idCapEvaPrg === preg.idCapEvaPrg ? 'bd-warning active-tema': 'bd-success')"
                    :id="'pregunta_' + (capEvaPrgSelected !== null && capEvaPrgSelected.idCapEvaPrg === preg.idCapEvaPrg ? 'nueva': '')"
                    >
                    <div class="alert alert-danger" role="alert" v-if="checkErrors(preg).length > 0">
                        <p style="margin-bottom: 0px;">
                            <ul style="margin-bottom: 0px;"><li v-for="(a, a_i) in checkErrors(preg)"> {{ a }}</li></ul>
                        </p>
                    </div>
                    <a v-if="capEvaPrgSelected === null || capEvaPrgSelected !== null && capEvaPrgSelected.idCapEvaPrg !== preg.idCapEvaPrg"
                       v-on:click="onSelectedCapEvaPrg(preg_index)"
                       :title="'click aqui para editar la pregunta: ' + preg.pregunta">
                        <h6>{{ preg.pregunta }}</h6>
                        <span>Puntaje: {{ preg.puntaje }}</span>
                        <span>{{ preg.c }}</span>
                        <div class="col-lg-12" v-if="preg.tipo !== 'T'">
                            <ul class="pd-l-10 mg-0  tx-13">
                                <li v-if="preg.capEvaPrgList !== undefined && preg.capEvaPrgList !== null" v-for="(resp, resp_index) in preg.capEvaPrgList" :class="(resp.esCorrecta ? 'tx-success' : '') + ' '"> {{ resp.respuesta }}</li>
                            </ul>
                        </div>
                        <div v-if="preg.tipo === 'T'" class="bd bg-gray-50 pd-y-15 pd-x-15 pd-sm-x-20 col-12">
                            <h6 class="tx-15 mg-b-3">Pregunta abierta al usuario</h6>
                        </div>
                    </a>
                    <div v-if="capEvaPrgSelected !== null && capEvaPrgSelected.idCapEvaPrg === preg.idCapEvaPrg && capEva !== null && capEva.estatus === 1">
                        <span v-on:click="capEvaPrgSelected = null">Terminar de editar</span>
                        <a class=" float-right tx-warning" v-on:click="onCapEvaPrgDelete(preg_index)" title="eliminar esta pregunta"><i class="typcn typcn-trash" ></i></a>
                        <h6>Pregunta</h6>
                        <textarea class="w-100 form-control-ds" v-model="capEvaPrgSelected.pregunta" rows="2" placeholder="Pregunta"  v-on:change="onCapEvaPrgEdit(preg_index)"></textarea>

                        <h6>Comentarios</h6>
                        <input type="text" class="w-100 form-control-ds" v-model="capEvaPrgSelected.comentarios" placeholder="Comentarios" v-if="capEvaPrgSelected.comentarios.length <= 90" v-on:change="onCapEvaPrgEdit(preg_index)" />
                        <textarea class="w-100 form-control-ds" v-model="capEvaPrgSelected.comentarios" rows="4" placeholder="Comentarios" v-if="capEvaPrgSelected.comentarios.length > 90" v-on:change="onCapEvaPrgEdit(preg_index)"></textarea>

                        <h6>Puntaje</h6>
                        <input type="number" class="w-50 form-control-ds" v-model="capEvaPrgSelected.puntaje" placeholder="Puntaje" v-on:change="onCapEvaPrgEdit(preg_index)" />

                        <h6>Tipo pregunta</h6>
                        <select v-model="capEvaPrgSelected.tipo" class="w-100 form-control-ds" v-on:change="onCapEvaPrgEdit(preg_index)">
                            <option v-for="option in view.listTipo" v-bind:value="option.value">
                                {{ option.text }}
                            </option>
                        </select>
                        <h6 v-if="capEvaPrgSelected.tipo === 'O' || capEvaPrgSelected.tipo === 'M'" class="mt-4">
                            Preguntas 
                        </h6>
                        <div v-if="capEvaPrgSelected.tipo === 'O' || capEvaPrgSelected.tipo === 'M'" v-for="(resp, resp_index) in capEvaPrgSelected.capEvaPrgList" class="w-100" style="margin-bottom: 0px;">
                            <label style="width: 97%;margin-bottom: 0px;">
                                <input type="checkbox" :id="'idCapEvaPrgRes_' + resp.idCapEvaPrgRes"  v-model="resp.esCorrecta" v-on:change="onCapEvaPrgResEdit(preg_index, resp_index)">
                                <input type="text" class="w-80 form-control-ds" v-model="resp.respuesta" placeholder="Respuesta" style="width: 90%;" v-on:change="onCapEvaPrgResEdit(preg_index, resp_index)" />
                            </label>
                            <a class=" float-right tx-warning" v-on:click="onCapEvaPrgResDelete(preg_index, resp_index)" title="eliminar esta respuesta" style="width: 3%;"><i class="typcn typcn-trash" ></i></a>
                        </div>
                        <div v-if="capEvaPrgSelected.tipo === 'O' || capEvaPrgSelected.tipo === 'M'" class="w-100 mt-3" style="margin-bottom: 0px;">
                            <input type="text" class="w-80 form-control-ds" v-model="capEvaPrgRes.respuesta" placeholder="Introduce aqui una nueva respuesta" style="width: 90%;" v-on:keyup.enter="onCapEvaPrgResAdd(preg_index)" />
                            <span class="tx-info tx-10" v-if="capEvaPrgRes.respuesta.trim() !== ''">Presiona enter para agregar</span>
                        </div>
                    </div>
                </div><!-- schedule-item -->
            </div><!-- schedule-group -->
            <button type="button" v-if="capEva !== null && capEva.estatus === 1" class="btn btn-sm btn-block btn-dark"  title="Agregar pregunta" v-on:click="onCapEvaPrgAdd()" id="btn_add_preg_ed"><i class="typcn typcn-document-plus"></i>Agregar una pregunta</button>
        </div>`,
    data: function () {
        return {
            error_DarkUI_exception: null,
            capEvaPrgList: [],
            capEvaPrgSelected: null,
            capEva: null,
            view: {
                listTipo: [
                    { value: 'T', text: 'Abierta - el usuario puede introducir texto' },
                    { value: 'O', text: 'Opcional - el usuario puede seleccionar una opción correcta' },
                    { value: 'M', text: 'Multiples opciones - el usuario puede seleccionar multiples opciones correctas' }
                ],
            },
            capEvaPrgRes: {
                respuesta: '',
                esCorrecta: false,
            },
        }
    },
    watch: {
        $route(to, from) {
            this.onCapEvaDetails();
            this.getCapEvaPrgList();
            this.capEvaPrgSelected = null
            document.getElementById("bt_eva_refres_version").click()
        }
    },
    async mounted() {
        await this.onCapEvaDetails();
        await this.getCapEvaPrgList();
    },
    events: {

    },
    methods: {
        oncFinisheditPreg: function () {
            this.capEvaPrgSelected = null
        },
        checkErrors: function (preg) {
            var error = [];
            if (preg.tipo === 'O' || preg.tipo === 'M') {
                if (preg.capEvaPrgList.length === 0) {
                    error.push("Sin preguntas")
                } else {
                    if (preg.tipo === 'O' && preg.capEvaPrgList.filter(a => a.esCorrecta === true).length === 0)
                        error.push("No se ha seleccionado la respuecta correcta")
                    else if (preg.tipo === 'O' && preg.capEvaPrgList.filter(a => a.esCorrecta === true).length > 1)
                        error.push("Solo debes seleccionar una respuesta correcta")

                    if (preg.tipo === 'M' && preg.capEvaPrgList.filter(a => a.esCorrecta === true).length === 0)
                        error.push("No se han seleccionado las respuestas correctas")
                }
            }
            return error;
        },
        onCapEvaDetails: async function () {
            this.capEvaPrgSelected = null
            await axios.get('../FormacionCapacitacion/CapEvaDetails?IdVersion=' + this.$route.params.idCapRegistryVersion + '&IdCapEva=' + this.$route.params.idCapEva, null, null).then(response => {
                this.capEva = response.data.eva
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapEvaPrgAdd: async function () {
            btn_loading(this.capEvaPrgList.length > 0 ? 'btn_add_preg_ed' : 'btn_add_preg_ed_1', 'Guardando...')

            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("IdVersion", this.$route.params.idCapRegistryVersion)
            formData.append("Pregunta", 'Pregunta')
            formData.append("Comentarios", '')
            formData.append("Puntaje", '10')
            formData.append("Tipo", 'O')
            formData.append("CapEvaPrgList[0].IdCapEvaPrgRes", 1)
            formData.append("CapEvaPrgList[0].IdCapEvaPrg", 1)
            formData.append("CapEvaPrgList[0].Respuesta", 'Respuesta 1')
            formData.append("CapEvaPrgList[0].EsCorrecta", false)
            formData.append("CapEvaPrgList[0].Creada", '2021-10-10 12:12:12')
            formData.append("CapEvaPrgList[0].Editada", '2021-10-10 12:12:12')

            await axios.post('../FormacionCapacitacion/CapEvaPrgAdd', formData, null).then(response => {
                // agregar la pregunta a la lista
                //this.capEvaPrgSelected = response.data
                this.getCapEvaPrgList()
                /*this.capEva_obj.capEvaPrg_list.push(response.data);*/
                btn_loading(this.capEvaPrgList.length > 0 ? 'btn_add_preg_ed' : 'btn_add_preg_ed_1', '<i class="typcn typcn-document-plus"></i>Agregar una pregunta', 'hide')
            }).catch(error => {
                GlobalValidAxios(error);
                btn_loading(this.capEvaPrgList.length > 0 ? 'btn_add_preg_ed' : 'btn_add_preg_ed_1', '<i class="typcn typcn-document-plus"></i>Agregar una pregunta', 'hide')
            }).finally(async () => {
                //document.getElementById("pregunta_nueva").focus()
                //

                //this.capEvaPrgSelected = this.capEvaPrgList.find(a => a.idCapEvaPrg === this.capEvaPrgSelected.idCapEvaPrg)
            })
        },
        onCapEvaPrgDelete: async function (preg_index) {
            //(int IdCapEva, int IdCapEvaPrg)
            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("IdVersion", this.$route.params.idCapRegistryVersion)
            formData.append("IdCapEvaPrg", this.capEvaPrgSelected.idCapEvaPrg)
            await axios.post('../FormacionCapacitacion/CapEvaPrgDelete', formData, null).then(response => {
                //// agregar la pregunta a la lista
                ShowMessageErrorShort('Pregunta eliminada', 'success')
                this.capEvaPrgSelected = null
                this.capEvaPrgList.splice(preg_index, 1);
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapEvaPrgEdit: async function (preg_index) {
            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("IdVersion", this.$route.params.idCapRegistryVersion)
            formData.append("IdCapEvaPrg", this.capEvaPrgSelected.idCapEvaPrg)
            formData.append("Pregunta", this.capEvaPrgSelected.pregunta)
            formData.append("Comentarios", this.capEvaPrgSelected.comentarios)
            formData.append("Puntaje", this.capEvaPrgSelected.puntaje)
            formData.append("Tipo", this.capEvaPrgSelected.tipo)
            await axios.post('../FormacionCapacitacion/CapEvaPrgEdit', formData, null).then(response => {
                //// agregar la pregunta a la lista
                ShowMessageErrorShort('Datos cambiados', 'success')
                //this.capEvaPrgRes.respuesta = ''

                this.capEvaPrgList[preg_index] = JSON.parse(JSON.stringify(this.capEvaPrgSelected))

            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapEvaPrgResAdd: async function (preg_index) {
            if (this.capEvaPrgRes.respuesta.trim() !== '') {
                let formData = new FormData();
                formData.append("IdCapEva", this.$route.params.idCapEva)
                formData.append("IdVersion", this.$route.params.idCapRegistryVersion)
                formData.append("IdCapEvaPrgRes", 1)
                formData.append("IdCapEvaPrg", this.capEvaPrgSelected.idCapEvaPrg)
                formData.append("Respuesta", this.capEvaPrgRes.respuesta.trim())
                formData.append("EsCorrecta", this.capEvaPrgRes.esCorrecta)
                formData.append("Creada", '2021-10-10 12:12:12')
                formData.append("Editada", '2021-10-10 12:12:12')
                await axios.post('../FormacionCapacitacion/CapEvaPrgResAdd', formData, null).then(response => {
                    // agregar la pregunta a la lista
                    this.capEvaPrgSelected.capEvaPrgList.push(response.data);
                    this.capEvaPrgRes.respuesta = ''
                    this.capEvaPrgList[preg_index] = JSON.parse(JSON.stringify(this.capEvaPrgSelected))

                    ShowMessageErrorShort('Respuesta agregada correctamente', 'success')
                }).catch(error => {
                    GlobalValidAxios(error);
                }).finally(() => {

                })
            }
        },
        onCapEvaPrgResEdit: async function (preg_index, resp_index) {
            if (this.capEvaPrgSelected.capEvaPrgList[resp_index].respuesta === '') {
                this.capEvaPrgSelected.capEvaPrgList[resp_index].respuesta = 'Respuesta'
            }
            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("IdVersion", this.$route.params.idCapRegistryVersion)
            formData.append("CapEvaPrgRes", this.capEvaPrgSelected.capEvaPrgList[resp_index].idCapEvaPrgRes)
            formData.append("IdCapEvaPrg", this.capEvaPrgSelected.capEvaPrgList[resp_index].idCapEvaPrg)
            formData.append("Respuesta", this.capEvaPrgSelected.capEvaPrgList[resp_index].respuesta.trim())
            formData.append("EsCorrecta", this.capEvaPrgSelected.capEvaPrgList[resp_index].esCorrecta)
            await axios.post('../FormacionCapacitacion/CapEvaPrgResEdit', formData, null).then(response => {
                //// agregar la pregunta a la lista
                this.capEvaPrgList[preg_index].capEvaPrgList[resp_index].respuesta = this.capEvaPrgSelected.capEvaPrgList[resp_index].respuesta.trim() + ""
                this.capEvaPrgList[preg_index].capEvaPrgList[resp_index].esCorrecta = this.capEvaPrgSelected.capEvaPrgList[resp_index].esCorrecta


                //this.capEvaPrgList[preg_index].capEvaPrgList[resp_index] = JSON.parse(JSON.stringify(this.capEvaPrgSelected.capEvaPrgList[resp_index]))
                ShowMessageErrorShort('Respuesta actualizada correctamente', 'success')
                //this.capEvaPrgRes.respuesta = ''
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapEvaPrgResDelete: async function (preg_index, resp_index) {
            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("IdVersion", this.$route.params.idCapRegistryVersion)
            formData.append("IdCapEvaPrg", this.capEvaPrgSelected.idCapEvaPrg)
            formData.append("CapEvaPrgRes", this.capEvaPrgSelected.capEvaPrgList[resp_index].idCapEvaPrgRes)
            await axios.post('../FormacionCapacitacion/CapEvaPrgResDelete', formData, null).then(response => {
                //// agregar la pregunta a la lista
                this.capEvaPrgSelected.capEvaPrgList.splice(resp_index, 1)
                this.capEvaPrgList[preg_index] = JSON.parse(JSON.stringify(this.capEvaPrgSelected))
                ShowMessageErrorShort('Respuesta eliminada correctamente', 'success')
                //this.capEvaPrgRes.respuesta = ''
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onSelectedCapEvaPrg: function (index) {
            if (this.capEva !== null && this.capEva.estatus === 1) {
                //if (this.capEva !== null) {
                this.capEvaPrgSelected = JSON.parse(JSON.stringify(this.capEvaPrgList[index]))
            }
        },
        getCapEvaPrgResList: async function () {
            this.capEvaPrgList.forEach(async (preg, preg_index) => {
                await axios.get('../FormacionCapacitacion/CapEvaPrgResList?IdCapEvaPrg=' + preg.idCapEvaPrg, null, null).then(response => {
                    preg.capEvaPrgResList = response.data
                }).catch(error => {
                    GlobalValidAxios(error);
                }).finally(() => {

                })
                console.log(preg)
            })
        },
        getCapEvaPrgList: async function () {
            console.log("loadding preguntas")

            await axios.get('../FormacionCapacitacion/capEvaPrgList?IdVersion=' + this.$route.params.idCapRegistryVersion + '&IdCapEva=' + this.$route.params.idCapEva, null, {
                onUploadProgress: function (progressEvent) {
                    //var percentCompleted = Math.round((progressEvent.loaded * 100) / progressEvent.total);
                    console.log("asdasdadadasdas: ")
                }
            }).then(response => {
                //response.data.forEach(async (preg, preg_index) => { preg['capEvaPrgResList'] = [] });
                this.capEvaPrgList = response.data
                ShowMessageErrorShort("", "success")
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
            //await this.getCapEvaPrgResList();
        },
    },
}

const EvaPregAdd = {
    template: `
        <div>
            <div class="col-12">
                <div class="card mg-b-20 mg-lg-b-5">
                    <div class="card-header pd-y-15 pd-x-20 d-flex align-items-center justify-content-between">
                        <h6 class="tx-uppercase tx-semibold mg-b-0">Nueva pregunta</h6>
                    </div>
                    <div class="card-body pd-l-25 pd-r-25">
                        <div class="form-group mt-2" style="margin-bottom: 1px !important">
                            <label for="capEvaPrg_pregunta" class="">Pregunta </label>
                            <textarea class="form-control form-control-sm" id="capEvaPrg_pregunta" v-model="capEvaPrg.pregunta" placeholder="Pregunta" rows="1"></textarea>
                        </div>
                        <div class="form-group " style="margin-bottom: 1px !important">
                            <label for="capEvaPrg_comentarios" class="">Comentarios</label>
                            <input type="text" class="form-control form-control-sm" id="capEvaPrg_comentarios" v-model="capEvaPrg.comentarios" placeholder="Comentarios">
                        </div>
                        <div class="form-group " style="margin-bottom: 1px !important">
                            <label for="capEvaPrg_puntaje" class="">Puntaje</label>
                            <input type="number" class="form-control form-control-sm" id="capEvaPrg_puntaje" v-model="capEvaPrg.puntaje" placeholder="Puntaje">

                        </div>
                        <div class="form-group " style="margin-bottom: 1px !important">
                            <label for="capEvaPrg_tipo" class="">Tipo de pregunta</label>
                            <select v-model="capEvaPrg.tipo" class="form-control form-control-sm" id="capEvaPrg_tipo">
                                <option v-for="option in listTipo" v-bind:value="option.value">
                                    {{ option.text }}
                                </option>
                            </select>
                        </div>
                        
                        
                    </div>
                </div>
            </div>
            <div class="col-12" v-if="capEvaPrg.tipo === 'O' || capEvaPrg.tipo === 'M'">
                <div class="card mg-b-20 mg-lg-b-5" v-if="capEvaPrg !== null ">
                    <div class="card-body pd-l-25 pd-r-25">
                        <div class="form-group row mt-3" style="margin-bottom: 1px !important;margin-right: 1px;margin-left: 1px;"  >
                            <table class="table table-sm ">
                                <thead>
                                    <tr>
                                        <th colspan="3" class="tx-center tx-uppercase bg-light">Respuestas</th>
                                    </tr>
                                    <tr>
                                        <th class=" ">Respuesta</th>
                                        <th class=" " style="width: 100px;">Es correcta</th>
                                        <th class=" " style="width: 100px;"></th>
                                    </tr>
                                    <tr>
                                        <th>
                                            <input type="text" class="form-control form-control-sm" id="capEvaPrgRes_respuesta" v-model="capEvaPrgRes.respuesta" placeholder="Enter para agregar respuesta" rows="1" v-on:keyup.enter="addRespuesta()">
                                            <span v-if="capEvaPrgRes.respuesta.trim() !== ''" class="tx-info tx-11">Presiona enter para agregar</span>
                                        </th>
                                        <th colspan="1" class="text-center" style="vertical-align: middle;">
                                        </th>
                                        <th colspan="1" class="text-center" style="vertical-align: middle;">
                                            <button class="btn btn-sm btn-primary" title="Agregar respuesta" v-on:click="addRespuesta()">+</button>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="(resp, resp_index) in capEvaPrg.respuestas">
                                        <td>
                                            
                                            <input type="text" class="" class="form-control form-control-sm" v-bind:id="'resp_respuesta_' + resp_index" v-model="resp.respuesta" placeholder="Respuesta">
                                        </td>
                                        <td  class="text-center" style="vertical-align: middle;">
                                            <input type="checkbox" class="" v-bind:id="'resp_esCorrecta_' + resp_index" v-model="resp.esCorrecta" placeholder="Descripcion">
                                        </td>
                                        <td class="text-center" style="vertical-align: middle;">
                                            <button class="btn btn-sm btn-white" title="Eliminar respuesta" v-on:click="capEvaPrg.respuestas.splice(resp_index, 1)">x</button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div><!-- card-body -->
                </div><!-- card -->
            </div><!-- col -->
            <div class="col-12">
                <div class="card mg-b-20 mg-lg-b-5" v-if="capEvaPrg !== null ">
                    <div class="card-body pd-l-25 pd-r-25">
                        <div class="form-group row mg-b-0 mt-4">
                            <div class="col-sm-12 text-right">
                                <router-link :to="{ name: 'evaluacion-details', params: { idCapEva: $route.params.idCapEva } }" id="back_btn_add_preg" style="display:none" class="btn btn-sm btn-secondary">Cancelar</router-link>
                                <router-link :to="{ name: 'evaluacion-details', params: { idCapEva: $route.params.idCapEva } }" class="btn btn-sm btn-secondary">Cancelar</router-link>
                                <button type="button" class="btn btn-sm btn-primary" title="Guardar pregunta" v-if="capEvaPrg.pregunta !== '' && capEvaPrg.tipo !== ''" v-on:click="addPregunta()">Agregar</button>
                            </div>
                        </div>
                    </div><!-- card-body -->
                </div><!-- card -->
            </div><!-- col -->
        </div>`,
    data: function () {
        return {
            error_DarkUI_exception: null,
            capEvaPrg: {
                idCapEvaPr: 0,
                pregunta: '',
                comentarios: '',
                tipo: '',
                puntaje: 0,
                respuestas: []
            },
            listTipo: [
                { value: 'T', text: 'Abierta - el usuario puede introducir texto' },
                { value: 'O', text: 'Opcional - el usuario puede seleccionar una opción correcta' },
                { value: 'M', text: 'Multiples opciones - el usuario puede seleccionar multiples opciones correctas' }
            ],
            capEvaPrgRes: {
                respuesta: '',
                esCorrecta: '',

            },
        }
    },
    watch: {
        $route(to, from) {

        }
    },
    mounted() {
    },
    methods: {
        addPregunta: async function () {
            try {
                this.error_DarkUI_exception = null
                // validar informacion
                this.validatePreg();
                // validar si ya fue registrada la pregunta
                //if (this.capEva_obj.capEvaPrg_list.find(a => a.pregunta === this.capEvaPrg.pregunta) != undefined)
                //    throw new DarkUI_exception('Ya fue registrada esta pregunta', '');

                /*
                 * Ejecutar metodo web para registrar la pregunta
                 * */
                let formData = new FormData();
                formData.append("IdCapEva", this.$route.params.idCapEva)
                formData.append("Pregunta", this.capEvaPrg.pregunta)
                formData.append("Comentarios", this.capEvaPrg.comentarios)
                formData.append("Puntaje", this.capEvaPrg.puntaje)
                formData.append("Tipo", this.capEvaPrg.tipo)
                this.capEvaPrg.respuestas.forEach(async (e, i) => {
                    formData.append("CapEvaPrgList[" + i + "].IdCapEvaPrgRes", 1)
                    formData.append("CapEvaPrgList[" + i + "].IdCapEvaPrg", 1)
                    formData.append("CapEvaPrgList[" + i + "].Respuesta", e.respuesta)
                    formData.append("CapEvaPrgList[" + i + "].EsCorrecta", e.esCorrecta)
                    formData.append("CapEvaPrgList[" + i + "].Creada", '2021-10-10 12:12:12')
                    formData.append("CapEvaPrgList[" + i + "].Editada", '2021-10-10 12:12:12')


                });


                var inserted = null;
                await axios.post('../FormacionCapacitacion/CapEvaPrgAdd', formData, null).then(response => {
                    // agregar la pregunta a la lista
                    inserted = response.data
                    /*this.capEva_obj.capEvaPrg_list.push(response.data);*/
                }).catch(error => {
                    GlobalValidAxios(error);
                }).finally(() => {

                })
                // validar registro correcto de pregunta
                if (inserted === null || inserted === undefined || inserted.idCapEvaPrg === 0)
                    throw new DarkUI_exception('Error al registrar la pregunta, intenta nuevamente', '');

                document.getElementById("back_btn_add_preg").click()
                // limpiar form create pregunta
                this.capEvaPrg.pregunta = ''
                this.capEvaPrg.tipo = ''
                this.capEvaPrg.puntaje = 0
                this.capEvaPrg.respuestas = []
                this.capEvaPrg.selectedIndex = null
                this.capEvaPrg.mode = ''
                this.capEvaPrg.title = ''

            } catch (e) {
                this.error_DarkUI_exception = e
                $.alert({
                    title: 'Opps!',
                    content: e.message,
                    type: 'red'
                });
                console.error(e)
            }
        },
        validatePreg: function () {
            if (this.capEvaPrg.pregunta === '') {
                throw new DarkUI_exception('Introduce un texto valido para tu pregunta', '');
            }
            if (this.capEvaPrg.tipo === '') {
                throw new DarkUI_exception('Selecciona un tipo de pregunta', '');
            }

            if (this.capEvaPrg.tipo === 'O') {
                if (this.capEvaPrg.respuestas.length === 0) {
                    throw new DarkUI_exception('Define al menos una respuesta', '');
                }

                if (this.capEvaPrg.respuestas.filter(a => a.esCorrecta === true).length === 0) {
                    throw new DarkUI_exception('selecciona la respuesta correcta para poder continuar', '');
                }

                if (this.capEvaPrg.respuestas.filter(a => a.esCorrecta === true).length > 1) {
                    throw new DarkUI_exception('Solo puedes tener una respuesta correcta, si deseas mas de una opción selecciona tipo de pregunta: <strong>Multiples opciones</strong>', '');
                }
            }

            if (this.capEvaPrg.tipo === 'M') {
                if (this.capEvaPrg.respuestas.length === 0) {
                    throw new DarkUI_exception('Define al menos una respuesta', '');
                }
                if (this.capEvaPrg.respuestas.filter(a => a.esCorrecta === true).length === 0) {
                    throw new DarkUI_exception('Selecciona las respuestas correctas para continuar', '');
                }
            }
        },
        addRespuesta: function () {
            try {
                this.error_DarkUI_exception = null
                if (this.capEvaPrgRes.respuesta !== '') {
                    if (this.capEvaPrg.respuestas.find(a => a.respuesta === this.capEvaPrgRes.respuesta) !== undefined) {
                        throw new DarkUI_exception('Ya has gregado una opción similar a <strong>' + this.capEvaPrgRes.respuesta + '</strong>', '');
                    }
                    this.capEvaPrg.respuestas.push(JSON.parse(JSON.stringify(this.capEvaPrgRes)))
                    this.capEvaPrgRes.respuesta = ''
                }

            } catch (e) {
                this.error_DarkUI_exception = e
                $.alert({
                    title: 'Opps!',
                    content: e.message,
                    type: 'red'
                });
                console.error(e)
            }
        }
    },
}
/**/
const EvaPregEdit = {
    template: `
        <div>
            <div class="col-12">
                <div class="card mg-b-20 mg-lg-b-5" v-if="capEvaPrg !== null ">
                    <div class="card-header pd-y-15 pd-x-20 d-flex align-items-center justify-content-between">
                        <h6 class="tx-uppercase tx-semibold mg-b-0">Editar pregunta</h6>
                    </div>
                    <div class="card-body pd-l-25 pd-r-25">
                        <div class="form-group mt-2" style="margin-bottom: 1px !important">
                            <label for="capEvaPrg_pregunta" class="">Pregunta </label>
                            <textarea class="form-control form-control-sm" id="capEvaPrg_pregunta" v-model="capEvaPrg.pregunta" placeholder="Pregunta" rows="1"></textarea>
                        </div><!-- form-group -->
                        <div class="form-group " style="margin-bottom: 1px !important">
                            <label for="capEvaPrg_comentarios" class="">Comentarios</label>
                            <input type="text" class="form-control form-control-sm" id="capEvaPrg_comentarios" v-model="capEvaPrg.comentarios" placeholder="Comentarios">
                        </div><!-- form-group -->
                        <div class="form-group " style="margin-bottom: 1px !important">
                            <label for="capEvaPrg_puntaje" class="">Puntaje</label>
                            <input type="number" class="form-control form-control-sm" id="capEvaPrg_puntaje" v-model="capEvaPrg.puntaje" placeholder="Puntaje">

                        </div><!-- form-group -->
                        <div class="form-group " style="margin-bottom: 1px !important">
                            <label for="capEvaPrg_tipo" class="">Tipo de pregunta</label>
                            <select v-model="capEvaPrg.tipo" class="form-control form-control-sm" id="capEvaPrg_tipo">
                                <option v-for="option in listTipo" v-bind:value="option.value">
                                    {{ option.text }}
                                </option>
                            </select>
                        </div><!-- form-group -->
                        <div class="form-group row mg-b-0 mt-4">
                            <div class="col-sm-12 text-right">
                                <button type="button" class="btn btn-sm btn-primary" title="Guardar pregunta" v-if="capEvaPrg.pregunta !== '' && capEvaPrg.tipo !== ''" v-on:click="onCapEvaPrgEdit()">Guardar</button>
                            </div>
                        </div><!-- form-group -->
                    </div><!-- card-body -->
                </div><!-- card -->
            </div><!-- col -->
            <div class="col-12">
                <div class="card mg-b-20 mg-lg-b-5" v-if="capEvaPrg !== null ">
                    <div class="card-header pd-y-15 pd-x-20 d-flex align-items-center justify-content-between">
                        <h6 class="tx-uppercase tx-semibold mg-b-0">Respuestas</h6>
                    </div>
                    <div class="card-body pd-l-25 pd-r-25">
                        <div class="form-group row mg-b-0 mt-4" v-if="capEvaPrg.capEvaPrgList.filter(a => a.esCorrecta === true).length === 0">
                            <div class="alert alert-warning mg-b-0 col-12" role="alert">
                              Por favor selecciona la(s) respuesta(s) coorecta(s)
                            </div>
                        </div>
                        <div class="form-group row mg-b-0 mt-4" v-if="capEvaPrg.capEvaPrgList.filter(a => a.esCorrecta === true).length > 1 && capEvaPrg.tipo === 'O'">
                            <div class="alert alert-warning mg-b-0 col-12" role="alert">
                              Por selecciona solo una respuesta correcta, si deseas mas de una respuesta correcta selecciona el tipo de pregunta como: <strong>Multiples opciones</strong>
                            </div>
                        </div>
                        <div class="form-group row mt-3" style="margin-bottom: 1px !important;margin-right: 1px;margin-left: 1px;" v-if="capEvaPrg.tipo === 'O' || capEvaPrg.tipo === 'M'" >
                            <table class="table table-sm ">
                                <thead>
                                    <tr>
                                        <th class=" ">Respuesta</th>
                                        <th class=" " style="width: 100px;">Es correcta</th>
                                        <th class=" " style="width: 100px;"></th>
                                    </tr>
                                    <tr>
                                        <th>
                                            <input type="text" class="form-control form-control-sm" id="capEvaPrgRes_respuesta" v-model="capEvaPrgRes.respuesta" placeholder="Enter para agregar respuesta" v-on:keyup.enter="addRespuesta()">
                                            <span v-if="capEvaPrgRes.respuesta.trim() !== ''" class="tx-info tx-11">Presiona enter para agregar</span>
                                        </th>
                                        <th colspan="1" class="text-center" style="vertical-align: middle;">
                                        </th>
                                        <th colspan="1" class="text-center" style="vertical-align: middle;">
                                            <button class="btn btn-sm btn-primary" title="Agregar respuesta" v-on:click="addRespuesta()">+</button>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="(resp, resp_index) in capEvaPrg.capEvaPrgList">
                                        <td>
                                            <input type="text" class="form-control form-control-sm" v-bind:id="'resp_respuesta_' + resp_index" v-model="resp.respuesta" v-on:change="onCapEvaPrgResEdit(resp_index)" placeholder="Descripcion">
                                        </td>
                                        <td  class="text-center" style="vertical-align: middle;">
                                            <input type="checkbox" class="" v-bind:id="'resp_esCorrecta_' + resp_index" v-model="resp.esCorrecta" placeholder="Descripcion" v-on:change="onCapEvaPrgResEdit(resp_index)">
                                        </td>
                                        <td class="text-center" style="vertical-align: middle;"> <button class="btn btn-sm btn-white" title="Eliminar respuesta" v-on:click="onCapEvaPrgResDelete(resp_index)">x</button> </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div><!-- card-body -->
                </div><!-- card -->
            </div><!-- col -->
            <div class="col-12">
                <div class="card mg-b-20 mg-lg-b-5" v-if="capEvaPrg !== null ">
                    <div class="card-body pd-l-25 pd-r-25">
                        
                        <div class="form-group row mg-b-0 ">
                            <div class="col-sm-12 text-right">
                                <button type="button" class="btn btn-sm btn-danger" title="Eliminar pregunta" v-on:click="onCapEvaPrgDelete()">Eliminar</button>
                                <router-link :to="{ name: 'evaluacion-details', params: { idCapEva: $route.params.idCapEva } }" class="btn btn-sm btn-secondary" id="btn_go_to_evaluacion_details">Terminar</router-link>
                            </div>
                        </div>
                    </div><!-- card-body -->
                </div><!-- card -->
            </div><!-- col -->

        </div>
    `,
    data: function () {
        return {
            error_DarkUI_exception: null,
            capEvaPrg: null,
            listTipo: [
                { value: 'T', text: 'Abierta - el usuario puede introducir texto' },
                { value: 'O', text: 'Opcional - el usuario puede seleccionar una opción correcta' },
                { value: 'M', text: 'Multiples opciones - el usuario puede seleccionar multiples opciones correctas' }
            ],
            capEvaPrgRes: {
                respuesta: '',
                esCorrecta: '',

            },
        }
    },
    watch: {
        $route(to, from) {
            this.getCapEvaPrgDeetails();
        }
    },
    mounted() {
        this.getCapEvaPrgDeetails();
    },
    methods: {

        onCapEvaPrgDelete: async function () {
            //(int IdCapEva, int IdCapEvaPrg)
            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("IdCapEvaPrg", this.$route.params.idCapEvaPrg)
            await axios.post('../FormacionCapacitacion/CapEvaPrgDelete', formData, null).then(response => {
                //// agregar la pregunta a la lista
                ShowMessageErrorShort('Pregunta eliminada', 'success')
                document.getElementById("btn_go_to_evaluacion_details").click()
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapEvaPrgEdit: async function () {
            let formData = new FormData();
            formData.append("IdCapEva", this.$route.params.idCapEva)
            formData.append("IdCapEvaPrg", this.$route.params.idCapEvaPrg)
            formData.append("Pregunta", this.capEvaPrg.pregunta)
            formData.append("Comentarios", this.capEvaPrg.comentarios)
            formData.append("Puntaje", this.capEvaPrg.puntaje)
            formData.append("Tipo", this.capEvaPrg.tipo)
            await axios.post('../FormacionCapacitacion/CapEvaPrgEdit', formData, null).then(response => {
                //// agregar la pregunta a la lista
                ShowMessageErrorShort('Datos cambiados', 'success')
                //this.capEvaPrgRes.respuesta = ''
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapEvaPrgResDelete: async function (resp_index) {
            let formData = new FormData();

            formData.append("CapEvaPrgRes", this.capEvaPrg.capEvaPrgList[resp_index].idCapEvaPrgRes)
            formData.append("IdCapEvaPrg", this.capEvaPrg.capEvaPrgList[resp_index].idCapEvaPrg)
            await axios.post('../FormacionCapacitacion/CapEvaPrgResDelete', formData, null).then(response => {
                //// agregar la pregunta a la lista
                this.capEvaPrg.capEvaPrgList.splice(resp_index, 1)
                ShowMessageErrorShort('Respuesta eliminada correctamente', 'success')
                //this.capEvaPrgRes.respuesta = ''
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapEvaPrgResEdit: async function (resp_index) {
            if (this.capEvaPrg.capEvaPrgList[resp_index].respuesta !== '') {

                let formData = new FormData();

                formData.append("CapEvaPrgRes", this.capEvaPrg.capEvaPrgList[resp_index].idCapEvaPrgRes)
                formData.append("IdCapEvaPrg", this.capEvaPrg.capEvaPrgList[resp_index].idCapEvaPrg)
                formData.append("Respuesta", this.capEvaPrg.capEvaPrgList[resp_index].respuesta.trim())
                formData.append("EsCorrecta", this.capEvaPrg.capEvaPrgList[resp_index].esCorrecta)
                await axios.post('../FormacionCapacitacion/CapEvaPrgResEdit', formData, null).then(response => {
                    //// agregar la pregunta a la lista
                    this.capEvaPrg.capEvaPrgList[resp_index] = response.data;
                    ShowMessageErrorShort('Respuesta actualizada correctamente', 'success')
                    //this.capEvaPrgRes.respuesta = ''
                }).catch(error => {
                    GlobalValidAxios(error);
                }).finally(() => {

                })
            }
        },
        addRespuesta: async function () {
            try {
                this.error_DarkUI_exception = null
                if (this.capEvaPrgRes.respuesta !== '') {
                    if (this.capEvaPrg.capEvaPrgList.find(a => a.respuesta === this.capEvaPrgRes.respuesta) !== undefined) {
                        throw new DarkUI_exception('Ya has gregado una opción similar a <strong>' + this.capEvaPrgRes.respuesta + '</strong>', '');
                    }
                    let formData = new FormData();

                    formData.append("IdCapEvaPrgRes", 1)
                    formData.append("IdCapEvaPrg", this.$route.params.idCapEvaPrg)
                    formData.append("Respuesta", this.capEvaPrgRes.respuesta.trim())
                    formData.append("EsCorrecta", this.capEvaPrgRes.esCorrecta)
                    formData.append("Creada", '2021-10-10 12:12:12')
                    formData.append("Editada", '2021-10-10 12:12:12')
                    await axios.post('../FormacionCapacitacion/CapEvaPrgResAdd', formData, null).then(response => {
                        // agregar la pregunta a la lista
                        this.capEvaPrg.capEvaPrgList.push(response.data);
                        this.capEvaPrgRes.respuesta = ''
                        ShowMessageErrorShort('Respuesta agregada correctamente', 'success')
                    }).catch(error => {
                        GlobalValidAxios(error);
                    }).finally(() => {

                    })
                }

            } catch (e) {
                this.error_DarkUI_exception = e
                $.alert({
                    title: 'Opps!',
                    content: e.message,
                    type: 'red'
                });
                console.error(e)
            }
        },
        getCapEvaPrgDeetails: async function () {
            await axios.get('../FormacionCapacitacion/CapEvaPrgDeetails?IdCapEvaPrg=' + this.$route.params.idCapEvaPrg, null, null).then(response => {
                this.capEvaPrg = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }

    },
}

const template = {
    template: `
        <div>
        <div class="d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30">
                <div>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb breadcrumb-style1 mg-b-10">
                            <li class="breadcrumb-item active" aria-current="page">Templates</li>
                        </ol>
                    </nav>
                    <h4 class="mg-b-0 tx-spacing--1">Templates</h4>
                </div>
            </div>
            <div class="row row-xs mg-b-25">
                
                <div class="col-sm-4 col-md-3 col-lg-4 col-xl-3" v-for="(capTemp, capTemp_index) in capTemp_list">
                    <div class="card card-event">
                      <div class="card-body tx-13">
                        <h5>{{ capTemp.nombre }}</h5>
                        <p class="mg-b-0"></p>
                        <span class="tx-12 tx-color-03"></span>
                      </div><!-- card-body -->
                      <div class="card-footer tx-13">
                        <router-link class="btn btn-xs btn-secondary" :to="{ name: 'capacitacion-template-admin', params: { idCapTempl: capTemp.idCapTempl, idVersion : 0 } }">Ver</router-link>
                      </div><!-- card-footer -->
                    </div><!-- card -->
                </div><!-- col -->
                <div class="col-sm-4 col-md-3 col-lg-4 col-xl-3">
                    <div class="card card-profile">
                        <div class="card-body tx-13">
                                <button class="btn btn-block btn-dark" v-on:click="onBeforeCapTemplCreate()">Registrar nueva</button>
                        </div>
                    </div><!-- card -->
                </div><!-- col -->
            </div>
            <div class="modal fade" id="modal_add_template" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-lg " role="document">
                    <div class="modal-content">
                        <div class="modal-body pd-20 pd-sm-40">
                            <a href="" role="button" class="close pos-absolute t-15 r-15" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </a>
                            <div>
                                <h4>Diseñar nueva capacitacion</h4>
                                <div class="form-group">
                                    <label>Clave</label>
                                    <input type="text" class="form-control form-control-sm"  maxLength="20" v-model="capTemp.clave" placeholder="clave"/>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (20 - capTemp.clave.length) + ' / 20' }}</span>
                                </div>
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <textarea  class="form-control form-control-sm" id="captema_descripcion" maxLength="200" v-model="capTemp.nombre" placeholder="Nombre" rows="1"></textarea>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (200 - capTemp.nombre.length) + ' / 200' }}</span>
                                </div>
                                <div class="form-group">
                                    <label>Descripcion</label>
                                    <textarea  class="form-control form-control-sm" id="captema_descripcion" maxLength="300" v-model="capTemp.descripcion" placeholder="Descripcion" rows="3"></textarea>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (300 - capTemp.descripcion.length) + ' / 300' }}</span>
                                </div>
                                <div class="form-group">
                                    <label>Objetivo</label>
                                    <textarea  class="form-control form-control-sm" id="captema_descripcion" maxLength="250" v-model="capTemp.objetivo" placeholder="objetivo" rows="4"></textarea>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (250 - capTemp.objetivo.length) + ' / 250' }}</span>
                                </div>
                                <div class="form-group">
                                    <label>Calificación minima</label>
                                    <input type="number" class="form-control form-control-sm"  v-model="capTemp.calRepet" placeholder="clave"/>
                                </div>
                                <button class="btn btn-primary btn-block" :disabled="capTemp.clave === '' || capTemp.nombre === ''" title="Agregar sesión" v-on:click="onCapTemplCreate()" id="btn_add__templ">Agregar</button>
                            </div>
                        </div><!-- modal-body -->
                    </div><!-- modal-content -->
                </div><!-- modal-dialog -->
            </div><!-- modal -->
        </div>
    `,
    data: function () {
        return {
            error_DarkUI_exception: null,
            capTemp_list: [],
            capTemp: {
                idCapTempl: 1,
                clave: "",
                nombre: "",
                descripcion: "",
                objetivo: "",
                calRepet: 0,
                duracion: 0,
                estatus: 1,
                noSesions: 6,
                creada: "2021-10-04T13:54:42.203",
                editada: "2021-10-20T13:30:49.03"
            }
        }
    },
    watch: {
        $route(to, from) {
            this.onCapTemplList();
        }
    },
    mounted() {
        this.onCapTemplList();
    },
    methods: {
        onBeforeCapTemplCreate: function () {
            $("#modal_add_template").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onCapTemplCreate: async function () {
            btn_loading('btn_add__templ', '<i class="typcn typcn-plus"></i>Registrando..')
            let formData = new FormData();
            formData.append("IdCapTempl", this.capTemp.idCapTempl)
            formData.append("Clave", this.capTemp.clave)
            formData.append("Nombre", this.capTemp.nombre)
            formData.append("Descripcion", this.capTemp.descripcion)
            formData.append("Objetivo", this.capTemp.objetivo)
            formData.append("CalRepet", this.capTemp.calRepet)
            formData.append("Duracion", this.capTemp.duracion)
            formData.append("Estatus", this.capTemp.estatus)
            formData.append("NoSesions", this.capTemp.noSesions)
            formData.append("Creada", this.capTemp.creada)
            formData.append("Editada", this.capTemp.editada)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapTemplCreate', formData, null).then(response => {
                //// agregar la pregunta a la lista
                ShowMessageErrorShort('Template creado', 'success')
                router.push({ name: 'capacitacion-template-admin', params: { idCapTempl: response.data } })
                $("#modal_add_template").modal('hide')
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {
            })
        },
        onCapTemplList: async function () {
            await axios.get('../FormacionCapacitacion/CapTemplList', null, null).then(response => {
                this.capTemp_list = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
}

const template_admin = {
    template: `
        <div>
            <div class="d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30">
                <div>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb breadcrumb-style1 mg-b-10">
                            <li class="breadcrumb-item" aria-current="page">
                                <router-link :to="{ name: 'capacitacion-template-list' }">Templates</router-link>
                            </li>
                            <li class="breadcrumb-item active" aria-current="page">Detalle de template</li>
                        </ol>
                    </nav>
                    <h4 class="mg-b-0 tx-spacing--1">Detalle de template</h4>
                </div>
            </div>
            <div class="row" v-if="$route.params.idVersion === undefined || $route.params.idVersion === null || $route.params.idVersion === 0 || $route.params.idVersion === '0'">
                <h2 class="col-lg-12">Selecciona una versión</h2>
				<!--begin::Col-->
				<div class="col-lg-4 alert alert-success  ml-1 mr-1" role="alert" v-for="(log, log_index) in logChangesStatus">
					<router-link
                            :to="{ name: 'capacitacion-template-admin', params: { idCapTempl:  $route.params.idCapTempl, idVersion: log.idCapRegistryVersion } }"
                            :title="'click aqui para ver version'"
                            :id="'ver_version_ev_det_' + log.idCapRegistryVersion"
                            :class="'schedule-item'"
                        >
                            <h6 >{{ log.comentarios }}</h6>
                            <span class="tx-13 tx-danger" v-if="log.actual === false"> En proceso</span>
                            <span class="tx-13 tx-success" v-if="log.actual === true"> Disponible</span>
                            <span class="tx-13 tx-color-03"> {{ log.editada | fechaDate }}</span>
                            <span class="tx-13 tx-color-03"> {{ log.nombre }}</span>
                        </router-link>
				</div>
                <!--end::Col-->
            </div>
            <div class="row" v-if="capTemp !== null && $route.params.idVersion !== undefined && $route.params.idVersion !== null && $route.params.idVersion !== 0 && $route.params.idVersion !== '0'">
                <div class="col-12 mb-3" role="alert" v-if="logChangesStatus.length > 0 && logChangesStatus.find(a => a.idCapRegistryVersion === parseInt($route.params.idVersion)) !== undefined && logChangesStatus.find(a => a.idCapRegistryVersion === parseInt($route.params.idVersion)) !== null">
                    
                    <div class="input-group">
                        <select class="form-control" v-model="idVersionSelected" v-on:change="onSelectedVersion()">
                            <option value="0">Selecciona una version</option>
                            <option v-for="(log, log_index) in logChangesStatus" v-bind:value="log.idCapRegistryVersion" :disabled="$route.params.idVersion === log.idCapRegistryVersion">{{ log.comentarios }} </option>
                        </select>
                        <div class="input-group-append">
                            <button class="btn btn-outline-light" v-if="parseInt(this.$route.params.idVersion) !== 0" type="button" id="button-addon2" v-on:click="begoreCapTemplNewVersion()">Nueva</button>
                        </div>
                    </div>

                    <h5 class="tx-uppercase mt-4 mb-2">Version: {{ logChangesStatus.find(a => a.idCapRegistryVersion === parseInt($route.params.idVersion)).comentarios }}</h5>
                </div>
                <div v-if="logChangesStatus.length && onvalidSms1().show" :class="onvalidSms1().classs + ' col-12'" role="alert">
                        <h4 class="alert-heading">Estimado usuario!</h4>
                        <p v-html="onvalidSms1().message"></p>
                        <button type="button" v-if="onvalidSms1().publicar" class="btn btn-sm btn-block btn-dark"  title="publicar" v-on:click="onCapVersionSetActive(4)" id="btn_eva_version_publish">Publicar esta versión<i class="typcn typcn-world"></i></button>
                </div>
                <div class="col-3" >
                    <div class="card mg-b-20 mg-lg-b-5">
                        <div class="card-body pd-l-25 pd-r-25">
                            <div class="row" v-if="view.editCapTemp === false && capTemp.estatus === 1"><div class="col-12" ><a class=" float-right tx-warning" v-on:click="onBeforeCapTemplEdit()"><i class="typcn typcn-pencil"></i></a></div></div>
                            <dl class="row" style="font-size: 13px;" v-if="view.editCapTemp === false">
                                <dt class="col-12">
                                   Clave
                                </dt>
                                <dd class="col-12">
                                    {{ capTemp.clave }}
                                </dd>
                                <dt class="col-12">
                                    Nombre
                                </dt>
                                <dd class="col-12">
                                    {{ capTemp.nombre }}
                                </dd>
                                <dt class="col-12">
                                    Descripción
                                </dt>
                                <dd class="col-12">
                                    {{ capTemp.descripcion }}
                                </dd>
                                <dt class="col-12">
                                    Objetivo
                                </dt>
                                <dd class="col-12">
                                    {{ capTemp.objetivo }}
                                </dd>
                                <dt class="col-12">
                                    Calificación aceptada
                                </dt>
                                <dd class="col-12">
                                    {{ capTemp.calRepet }}
                                </dd>
                            </dl>
                            <div class="row" v-if="view.editCapTemp === true && capTemp.estatus === 1"><div class="col-12" ><a class=" float-right tx-warning" v-on:click="view.editCapTemp = false"><i class="typcn typcn-times"></i></a></div></div>
                            <div class="row" v-if="view.editCapTemp === true && capTemp.estatus === 1">
                                <div class="form-group col-12">
                                    <label>Calificación minima</label>
                                    <input type="text" class="form-control form-control-sm" maxLength="20" v-model="capTempSelected.clave" placeholder="Clave"/>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (20 - capTempSelected.clave.length) + ' / 20' }}</span>
                                </div>
                                <div class="form-group col-12">
                                    <label>Nombre</label>
                                    <textarea  class="form-control form-control-sm"  maxLength="200" v-model="capTempSelected.nombre" placeholder="Nombre" rows="5"></textarea>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (200 - capTempSelected.nombre.length) + ' / 200' }}</span>
                                </div>
                                <div class="form-group col-12">
                                    <label>Descripción</label>
                                    <textarea  class="form-control form-control-sm"  maxLength="300" v-model="capTempSelected.descripcion" placeholder="Descripción" rows="5"></textarea>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (300 - capTempSelected.descripcion.length) + ' / 300' }}</span>
                                </div>
                                <div class="form-group col-12">
                                    <label>Objetivo</label>
                                    <textarea  class="form-control form-control-sm"  maxLength="400" v-model="capTempSelected.objetivo" placeholder="Objetivo" rows="7"></textarea>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (400 - capTempSelected.objetivo.length) + ' / 400' }}</span>
                                </div>
                                <div class="form-group col-12">
                                    <label>Calificación minima</label>
                                    <input type="number" class="form-control form-control-sm"  v-model="capTempSelected.calRepet" placeholder="Calificación minima"/>
                                </div>
                                <button class="btn btn-dark btn-sm btn-block" :disabled="capTempSelected.descripcion === '' || capTempSelected.nombre === ''" title="Actualizar" v-on:click="onCapTemplEdit()" id="btn_update_capTempl">Actualizar <i class="typcn typcn-arrow-sync"></i></button>
                            </div>
                        </div><!-- card-body -->
                    </div><!-- card -->
                </div<!-- col -->
                <div class="col-6" v-if="'capacitacion-template-admin' === $route.name">
                    <div class="profile-update-option bg-white ht-50 bd d-flex justify-content-end mg-b-20 mg-lg-b-25 rounded" v-if="capTemp.estatus === 1">
                        <div class="d-flex align-items-center pd-x-20 mg-r-auto">
                            <i class="typcn typcn-pencil"></i> <a href="#" class="link-03 mg-l-10" v-on:click="onBeforeCapSessCreate()"><span class="d-none d-sm-inline">Nueva sesión</span></a>
                        </div>
                        <div class="wd-50 bd-l d-flex align-items-center justify-content-center">
                            <a class="link-03" data-toggle="tooltip" title="Postear una evaluación" v-on:click="beforeAddEva()"><i class="typcn typcn-document-add"></i></a>
                        </div>
                    </div>
                    <div  class="card mg-b-20 mg-lg-b-5" v-for="(shedule_, shedule_index) in shedule">
                        <div class="card-body pd-l-25 pd-r-25">
                            <card-session v-if="shedule_.tipo === 1" v-bind:estatus="capTemp.estatus" v-bind:shedule="shedule_" v-on:goto_details="goto_details(shedule_.idRefer)" v-bind:idVersion="$route.params.idVersion"></card-session>
                            <card-evaluation v-if="shedule_.tipo === 2" v-bind:estatus="capTemp.estatus" v-bind:idCapEva="shedule_.idRefer" v-bind:idCapTemplShedule="shedule_.idCapRegistryVersionDet" v-on:goto_deleteEva="goto_deleteEva(shedule_index)" v-bind:idVersion="shedule_.idVersion"></card-evaluation>
                        </div><!-- card-body -->
                    </div><!-- card -->
                    <div  class="card mg-b-20 mg-lg-b-5" v-if="shedule.length === 0">
                        <div class="card-body pd-l-25 pd-r-25">
                            <div class="content content-fixed content-auth-alt mt-5">
                                    <div class="container ht-100p tx-center mt-5">
                                        <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                                            <h4 class="tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5">Template vacio</h4>
                                            <div class="wd-70p wd-sm-250 wd-lg-300 mg-b-15"><img src="https://image.freepik.com/vector-gratis/feliz-campana-planificacion-seo-redes-sociales-ilustracion-plana-aislada_74855-10793.jpg" class="img-fluid" alt=""></div>
                                            <div class="mg-b-40">
                                            </div>
                                        </div>
                                    </div><!-- container -->
                                </div><!-- content -->
                        </div><!-- card-body -->
                    </div><!-- card -->
                    <button class="btn btn-block btn-sm pd-x-15 btn-danger btn-uppercase mg-l-5 mt-3" v-if="capTemp !== null && capTemp.estatus === 4 && $route.params.idVersion !== undefined" v-on:click="onCapVersionSetActive(2)" id="btn_eva_version_deactive" title="Desactivar esta versión"><i class="typcn typcn-document-text"></i> Desactivar esta versión</button>
                </div<!-- col -->
                <div class="col-9" v-if="'capacitacion-template-admin' !== $route.name">
                    <router-view ></router-view>
                </div<!-- col -->
                <div class="modal fade" id="modal_add_session_templ" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-body pd-20 pd-sm-40">
                                <a href="" role="button" class="close pos-absolute t-15 r-15" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </a>
                                <div>
                                    <h4>Crear nueva sesión</h4>
                                    <div class="form-group">
                                        <label>Nombre</label>
                                        <textarea  class="form-control form-control-sm" id="captema_descripcion" maxLength="100" v-model="sess_add.name" placeholder="Nombre" rows="7"></textarea>
                                        <span class="tx-danger tx-10 col-sm-12 text-right">{{ (100 - sess_add.name.length) + ' / 100' }}</span>
                                    </div>
                                    <button class="btn btn-primary btn-block" :disabled="sess_add.name === ''" title="Agregar sesión" v-on:click="onCapSessCreate()" id="btn_add_session_templ">Registrar</button>
                                </div>
                            </div><!-- modal-body -->
                        </div><!-- modal-content -->
                    </div><!-- modal-dialog -->
                </div><!-- modal -->
                <div class="modal fade" id="modal_add_eva_templ" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-body pd-20 pd-sm-40">
                                <a href="" role="button" class="close pos-absolute t-15 r-15" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </a>
                                <div>
                                    <div v-if="view.stepAddEva === 0" class="mb-3">
                                        <h4>Selecciona una evaluación</h4>
                                        <ul class="sidebar-nav mt-3">
                                            <li v-for="(eva_, eva_index) in versionesEva" :class="'nav-item ' + (view.showkeyEva === eva_.id ? 'bd-warning show active-tema' : '')">
                                                <a class="nav-link with-sub " v-on:click="view.showkeyEva = eva_.id">
                                                    <i class="typcn typcn-document-add m-2 tx-20"></i>
                                                    {{ eva_.name }}
                                                </a>
                                                <nav class="nav">
                                                    <div v-for="(ver_, ver_index) in eva_.versiones" :class="'media align-items-center' + (view.showkeyEvaver === ver_.id ? ' bd-warning active-tema' : '')">
                                                        <a v-on:click="view.showkeyEvaver = ver_.id">
                                                            <div class="avatar"><i :class="'typcn typcn-input-checked m-2 tx-15' + (view.showkeyEva === ver_.id ? 'tx-warning': '')"></i></div>
                                                        </a>
                                                        <div class="media-body pd-l-15" v-on:click="view.showkeyEvaver = ver_.id">
                                                            <h6 class="mg-b-2">{{ ver_.nombre }}</h6>
                                                            <span class="tx-13 tx-color-03">{{ ver_.autor }}</span>
                                                        </div>
                                                    </div>
                                                </nav>
                                            </li>
                                        </ul>
                                    </div>
                                    <div v-if="view.stepAddEva === 1" class="mb-3">
                                        <h4 class="mb-3">Confirmar evaluación</h4>
                                        <card-evaluation v-bind:idCapEva="view.showkeyEva" v-bind:idVersion="view.showkeyEvaver"></card-evaluation>
                                    </div>
                                    <button type="button" class="btn btn-sm btn-dark" :disabled="view.stepAddEva === 0" v-on:click="view.stepAddEva --">Atras</button>
                                    <button type="button" class="btn btn-sm btn-primary" v-if="view.stepAddEva < 1" :disabled="view.showkeyEvaver === 0" v-on:click="view.stepAddEva ++">Siguiente</button>
                                    <button type="button" class="btn btn-sm btn-primary" v-if="view.stepAddEva === 1" :disabled="view.showkeyEvaver === 0" v-on:click="onCapTemplEvaAdd()" id="btn_tmpl_add_eva">Agregar a capacitación</button>
                                </div>
                            </div><!-- modal-body -->
                        </div><!-- modal-content -->
                    </div><!-- modal-dialog -->
                </div><!-- modal -->
                <div class="modal fade" id="modal_add_cap_version" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                                              <h3 class="tx-16 tx-sm-20 tx-md-24 mg-b-15 mg-md-b-20">Crear nueva versión</h3>
                                              <p class="tx-14 tx-md-16 tx-color-02">Introduce los siguientes datos para continuar..</p>
                                             <div class="form-group">
                                                <label>Comentarios</label>
                                                <textarea class="form-control" rows="2" placeholder="Comentarios" v-model="comentarios"></textarea>
                                            </div>
                                            <button class="btn btn-dark btn-sm btn-block" :disabled="comentarios === ''" v-on:click="onCapTemplNewVersion()" id="btn_add_capp_version">Crear</button>
                                        </div>
                                    </div><!-- col -->
                                </div><!-- row -->
                            </div><!-- modal-body -->
                        </div><!-- modal-content -->
                    </div><!-- modal-dialog -->
                </div><!-- modal -->
            </div>
        </div>
    `,
    data: function () {
        return {
            error_DarkUI_exception: null,
            capTemp: null,
            logChangesStatus: [],
            shedule: [],
            versionesEva: [],
            sess_add: {
                name: ''
            },
            capTempSelected: {
                nombre: '',
                descripcion: '',
                objetivo: '',
                calRepet: 0
            },
            view: {
                editCapTemp: false,
                showkeyEva: 0,
                showkeyEvaver: 0,
                stepAddEva: 0
            },
            idVersionSelected: 0,
            comentarios: ''
        }
    },
    watch: {
        $route(to, from) {
            if (this.$route.params.idVersion !== undefined && this.$route.params.idVersion !== null && this.$route.params.idVersion !== '0' && this.$route.params.idVersion !== 0) {
                this.shedule = []
                this.onCapTemplDetails()
                this.onGetShedule();
                this.onCapEvaVersions();
                this.idVersionSelected = parseInt(this.$route.params.idVersion)
                this.view.showkeyEva = 0
                this.view.showkeyEvaver = 0
                this.view.showkeyEva = 0
            }
            this.onCapVersionList();

        }
    },
    mounted() {
        if (this.$route.params.idVersion !== undefined && this.$route.params.idVersion !== null && this.$route.params.idVersion !== '0' && this.$route.params.idVersion !== 0) {
            this.shedule = []
            this.onCapTemplDetails()
            this.onGetShedule();
            this.onCapEvaVersions();
            this.idVersionSelected = parseInt(this.$route.params.idVersion)
            this.view.showkeyEva= 0
            this.view.showkeyEvaver= 0
            this.view.showkeyEva= 0
        }

        this.onCapVersionList();
    },
    methods: {
        onCapVersionSetActive: async function (estatus) {
            var title = ""
            var text = ""
            var btn_id = ""
            var btn_idAction = ""
            if (estatus === 4) {
                title = "¿Deseas publicar esta versión?"
                text = "despues de publicar podrá ser usada esta versión"
                btn_id = "btn_eva_version_publish"
                btn_idAction = "Publicar"
            } else if (estatus === 2) {
                title = "¿Deseas desactivar esta versión?"
                text = "despues de desactivar no podrá ser usada y modificada esta versión"
                btn_id = "btn_eva_version_deactive"
                btn_idAction = "Desactivar"
            }

            try {
                await Swal.fire({
                    title: title,
                    text: text,
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Si, adelante!'
                }).then(async (result) => {
                    if (!result.isConfirmed) {
                        throw new DarkUI_exception('proceso cancelado', '', true);
                    }
                })

                btn_loading(btn_id, 'Procesando...')
                let formData = new FormData();
                formData.append("IdCapTempl", this.$route.params.idCapTempl)
                formData.append("IdVersion", this.$route.params.idVersion)
                formData.append("Estatus", estatus)
                formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)

                await axios.post('../FormacionCapacitacion/CapTemplChageStatus', formData, null).then(response => {
                    // agregar la pregunta a la lista
                    this.capTemp.estatus = estatus
                    window.location.reload()
                    btn_loading(btn_id, btn_idAction, 'hide')
                }).catch(error => {
                    GlobalValidAxios(error);
                    btn_loading(btn_id, btn_idAction, 'hide')
                }).finally(() => {

                })


            } catch (e) {
                console.log(e)
            }
        },
        onvalidSms1: function () {
            var alertGl = {
                classs: "",
                message: "",
                publicar: false,
                show: false
            }
            if (this.$route.params.idVersion === undefined || this.$route.params.idVersion === null) {
                alertGl.show = false;
                alertGl.message = 'Por favor selecciona una versión para poder administrar';
                alertGl.classs = 'alert alert-info';
            } else {
                if (this.capTemp !== undefined && this.capTemp !== null) {
                    if (this.capTemp.estatus === 4) {
                        alertGl.show = true;
                        alertGl.message = 'Esta capacitacion se encuentra <strong class="tx-uppercase">disponible</strong>, ahora podrás utilizarla en cualquier capacitación, si deseas modificarla por favor crea una versión nueva';
                        alertGl.classs = 'alert alert-success';
                    }
                    else if (this.capTemp.estatus === 2) {
                        alertGl.show = true;
                        alertGl.message = 'Esta capacitacion ha sido <strong class="tx-uppercase">Inactiva</strong>, ahora no podra ser editada y usada en nuevas capacitacion';
                        alertGl.classs = 'alert alert-info';
                    }
                    else if (this.capTemp.estatus === 3) {
                        alertGl.show = true;
                        alertGl.message = 'Esta capacitacion ha sido <strong class="tx-uppercase">Eliminada</strong>';
                        alertGl.classs = 'alert alert-warning';
                    } else {
                        alertGl.show = true;
                        alertGl.message = 'Esta versión actualmente se encuentra en <strong class="tx-uppercase">proceso de desarrollo</strong> y no podrá ser usada en alguna capacitación, por favor da click en <strong>Publicar esta versión</strong> para que pueda ser usada.';
                        alertGl.classs = 'alert alert-info';
                        alertGl.publicar = true
                    }
                }
            }
            //{ { $route.params.idCapRegistryVersion } }
            //{ {  } }
            //{ { logChangesStatus.find(a => a.idCapRegistryVersion === $route.params.idCapRegistryVersion).actual } }
            return alertGl;
        },
        onCapTemplEvaAdd: async function () {
            //(int IdCapTempl, int IdVersion, int IdEvaCap, int IdVersionEva)
            
            btn_loading('btn_tmpl_add_eva', 'Registrando...')
            let formData = new FormData();
            formData.append("IdCapTempl", this.$route.params.idCapTempl)
            formData.append("IdVersion", this.$route.params.idVersion)
            formData.append("IdEvaCap", this.view.showkeyEva)
            formData.append("IdVersionEva", this.view.showkeyEvaver)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapTemplEvaAdd', formData, null).then(async (response) => {
                // agregar la pregunta a la lista
                await this.logChangesStatus.push(response.data)
                //document.getElementById("btn_preg_list_refresh").click()
                btn_loading('btn_tmpl_add_eva', 'Agregar a capacitación', 'hide')
                this.shedule.push(response.data)
                this.view.showkeyEva = 0
                this.view.showkeyEvaver = 0
                $("#modal_add_eva_templ").modal("hide")
            }).catch(error => {
                GlobalValidAxios(error);
                btn_loading('btn_tmpl_add_eva', 'Agregar a capacitación', 'hide')
            }).finally(() => {

            })
        },
        onCapEvaVersions: async function () {
            await axios.get('../FormacionCapacitacion/CapEvaVersions', null, null).then(response => {
                this.versionesEva = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        beforeAddEva: function () {
            this.onCapEvaVersions();
            this.view.showkeyEva = 0
            this.view.showkeyEvaver = 0
            $("#modal_add_eva_templ").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        begoreCapTemplNewVersion: function () {
            $("#modal_add_cap_version").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onCapTemplNewVersion: async function () {
            btn_loading('btn_add_capp_version', 'Guardando...')
            let formData = new FormData();
            formData.append("IdCapTempl", this.$route.params.idCapTempl)
            formData.append("IdVersion", this.$route.params.idVersion)
            formData.append("Comentarios", this.comentarios)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapTemplNewVersion', formData, null).then(async (response) => {
                // agregar la pregunta a la lista
                await this.logChangesStatus.push(response.data)
                //document.getElementById("btn_preg_list_refresh").click()
                btn_loading('btn_add_capp_version', 'Guardar', 'hide')
                router.push({ name: 'capacitacion-template-admin', params: { idCapTempl: this.$route.params.idCapTempl, idVersion: response.data.idCapRegistryVersion } })
                $("#modal_add_cap_version").modal("hide")
                this.comentarios = ""
            }).catch(error => {
                GlobalValidAxios(error);
                btn_loading('btn_add_capp_version', 'Guardar', 'hide')
            }).finally(() => {

            })
        },
        onSelectedVersion: async function () {
            router.push({ name: 'capacitacion-template-admin', params: { idCapTempl: this.$route.params.idCapTempl, idVersion: this.idVersionSelected } })
        },
        onCapVersionList: async function () {
            await axios.get('../FormacionCapacitacion/CapVersionList?TipoRef_=TEMP&IdRefer_=' + this.$route.params.idCapTempl, null, null).then(response => {
                this.logChangesStatus = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapTemplEdit: async function () {
            btn_loading('btn_update_capTempl', 'Actualizando... <i class="typcn typcn-arrow-sync"></i>')
            let formData = new FormData();
            formData.append("IdCapTempl", this.$route.params.idCapTempl)
            formData.append("idVersion", this.$route.params.idVersion)
            formData.append("Clave", this.capTempSelected.clave)
            formData.append("Nombre", this.capTempSelected.nombre)
            formData.append("Descripcion", this.capTempSelected.descripcion)
            formData.append("Objetivo", this.capTempSelected.objetivo)
            formData.append("CalRepet", this.capTempSelected.calRepet)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapTemplEdit', formData, null).then(response => {
                //// agregar la pregunta a la lista
                ShowMessageErrorShort('Sesión agregada', 'success')
                btn_loading('btn_update_capTempl', 'Actualizar <i class="typcn typcn-arrow-sync"></i>', 'hide')
                this.view.editCapTemp = false
                this.capTemp.clave = this.capTempSelected.clave + '';
                this.capTemp.nombre = this.capTempSelected.nombre + '';
                this.capTemp.descripcion = this.capTempSelected.descripcion + '';
                this.capTemp.objetivo = this.capTempSelected.objetivo + '';
                this.capTemp.calRepet = this.capTempSelected.calRepet
            }).catch(error => {
                GlobalValidAxios(error);
                btn_loading('btn_update_capTempl', 'Actualizar <i class="typcn typcn-arrow-sync"></i>', 'hide')
            }).finally(() => {
            })
        },
        onBeforeCapTemplEdit: function () {
            this.capTempSelected.clave = this.capTemp.clave + '';
            this.capTempSelected.nombre = this.capTemp.nombre + '';
            this.capTempSelected.descripcion = this.capTemp.descripcion + '';
            this.capTempSelected.objetivo = this.capTemp.objetivo + '';
            this.capTempSelected.calRepet = this.capTemp.calRepet + 0
            this.view.editCapTemp = true
        },
        onBeforeCapSessCreate: function () {
            $("#modal_add_session_templ").modal({
                backdrop: "static", //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onCapSessCreate: async function () {
            btn_loading('btn_add_session_templ', '<i class="typcn typcn-plus"></i>Registrando...')
            let formData = new FormData();
            formData.append("IdCapTempl", this.$route.params.idCapTempl)
            formData.append("idVersion", this.$route.params.idVersion)
            formData.append("IdCapSess", '1')
            formData.append("NoSession", '1')
            formData.append("Duracion", '1')
            formData.append("Eliminada", 'false')
            formData.append("Nombre", this.sess_add.name)
            formData.append("Creada", '2021-10-20')
            formData.append("Editada", '2021-10-20')
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapSessCreate', formData, null).then(response => {
                //// agregar la pregunta a la lista
                this.sess_add.name = ''
                btn_loading('btn_add_session_templ', 'Registrar')
                ShowMessageErrorShort('Sesión agregada', 'success')
                router.push({ name: 'admin-session-edit', params: { idCapSess: response.data.idCapSess } })
                $("#modal_add_session_templ").modal('hide')
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {
                btn_loading('btn_add_session_templ', 'Registrar')
            })
        },
        goto_deleteEva: function (index) {
            this.shedule.splice(index, 1)
        },
        goto_details: function (idRefer) {
            router.push({ name: 'admin-session-edit', params: { idCapSess: idRefer } })
        },
        onCapTemplDetails: async function () {
            await axios.get('../FormacionCapacitacion/CapTemplDetails?id=' + this.$route.params.idCapTempl + '&IdVersion=' + this.$route.params.idVersion, null, null).then(response => {
                this.capTemp = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onGetShedule: async function () {

            await axios.get('../FormacionCapacitacion/GetShedule?id=' + this.$route.params.idCapTempl + '&IdVersion=' + this.$route.params.idVersion, null, null).then(response => {
                this.shedule = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
}

const CapTemplSessEdit = {
    template: `
        <div>
            <nav class="navbar navbar-light bg-light">
                <router-link class="navbar-brand" :to="{ name: 'capacitacion-template-admin', params: { idCapSess: $route.params.idCapTempl } }" data-toggle="tooltip" title="Postear una evaluación"><i class="typcn typcn-arrow-left"></i>Regresar a detalle de template</router-link>
            </nav>
            <div class="col-12 mt-2 row">
                <div class="col-12" v-if="capSess != null && capSess.eliminada === true">
                     <div  class="card mg-b-20 mg-lg-b-5" >
                        <div class="card-body pd-l-25 pd-r-25">
                            <div class="content content-fixed content-auth-alt mt-5">
                                    <div class="container ht-100p tx-center mt-5">
                                        <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                                            <h4 class="tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5">Esta sesión fue eliminada</h4>
                                            <div class="wd-70p wd-sm-250 wd-lg-300 mg-b-15"><img src="https://image.freepik.com/vector-gratis/feliz-campana-planificacion-seo-redes-sociales-ilustracion-plana-aislada_74855-10793.jpg" class="img-fluid" alt=""></div>
                                            <div class="mg-b-40">
                                            </div>
                                        </div>
                                    </div><!-- container -->
                                </div><!-- content -->
                        </div><!-- card-body -->
                    </div><!-- card -->
                </div>
                <div class="col-8" v-if="capSess !== null && capSess.eliminada === false">
                    <div class="card mg-b-20 mg-lg-b-5">
                        <div class="card-header pd-t-20 d-sm-flex align-items-start justify-content-between bd-b-0 pd-b-0">
                            <div>
                                <h5 class="mg-b-5">Detalle de la sesión</h5>
                                <p class="tx-13 tx-color-03 mg-b-0"></p>
                            </div>
                            <div class="d-flex mg-t-20 mg-sm-t-0" v-if="capTemp.estatus === 1">
                                <div class="btn-group flex-fill">
                                    <a class=" float-right tx-warning"  v-if="view.editSess === false" v-on:click="view.editSess = true"><i class="typcn typcn-pencil"></i></a>
                                    <a class=" float-right tx-warning"  v-if="view.editSess === true" v-on:click="view.editSess = false"><i class="typcn typcn-times"></i></a>
                                </div>
                            </div>
                        </div><!-- card-header -->
                        <div class="card-body pd-l-25 pd-r-25">
                            <dl class="row" style="font-size: 13px;" v-if="view.editSess === false">
                                <dt class="col-12">
                                    Nombre
                                </dt>
                                <dd class="col-12">
                                    {{ capSess.nombre }}
                                </dd>
                                <dt class="col-12">
                                    Objetivo
                                </dt>
                                <dd class="col-12">
                                    {{ capSess.objetivo }}
                                </dd>
                                <dt class="col-12">
                                    Duracion
                                </dt>
                                <dd class="col-12">
                                    {{ capSess.duracion }}
                                </dd>
                            </dl>
                            <div class="col-12" v-if="view.editSess === true && capTemp.estatus === 1">
                                <div class="form-group mt-2" style="margin-bottom: 1px !important">
                                    <label for="capSess_nombre" class="">Nombre </label>
                                    <input type="text" class="form-control form-control-sm" id="capSess_nombre" maxLength="100" v-model="capSess.nombre" placeholder="Nombre de la sesión">
                                </div><!-- form-group -->
                                <div class="form-group mt-2" style="margin-bottom: 1px !important">
                                    <label for="capTema_nombre" class="">Objetivo </label>
                                    <textarea  class="form-control form-control-sm" id="capTema_nombre" maxLength="300" v-model="capSess.objetivo" placeholder="Objetivo" rows="3"></textarea>
                                    <span class="tx-danger tx-10 col-sm-12 text-right">{{ (300 - capSess.objetivo.length) + ' / 300' }}</span>
                                </div><!-- form-group -->
                                <div class="form-group " style="margin-bottom: 1px !important">
                                    <label for="capSess_duracion" class="">Duración</label>
                                    <input type="text" class="form-control form-control-sm" id="capSess_duracion" v-model="capSess.duracion" placeholder="Duracion en hrs">
                                </div><!-- form-group -->
                                <div class="form-group row mg-b-0 mt-4">
                                    <div class="col-sm-12 text-right">
                                        <button type="button" class="btn btn-sm btn-dark" title="Guardar pregunta" v-if="capSess.nombre !== ''" v-on:click="onCapSessEdit()" id="btn_sessio_update">Actualizar <i class="typcn typcn-arrow-sync"></i></button>
                                    </div>
                                </div><!-- form-group -->
                            </div><!-- col 12 -->
                        </div><!-- card-body -->
                    </div><!-- card -->
                    <div class="card mg-b-20 mg-lg-b-5" v-if="capSess !== null ">
                        <div class="card-header pd-t-20 d-sm-flex align-items-start justify-content-between bd-b-0 pd-b-0">
                            <div>
                                <h5 class="mg-b-5">Lista de temas</h5>
                                <p class="tx-13 tx-color-03 mg-b-0"></p>
                            </div>
                            <div class="d-flex mg-t-20 mg-sm-t-0">
                                <div class="btn-group flex-fill" v-if="capTemp.estatus === 1">
                                    <a class=" float-right tx-warning btn-ripple" title="Agregar nuevo tema" v-on:click="view.addTema = !view.addTema"><i class="typcn typcn-document-add"></i></a>
                                </div>
                            </div>
                        </div><!-- card-header -->
                        <div class="card-body pd-l-25 pd-r-25 row">
                            <div class="col-12">
                                <div class="schedule-group">
                                    <a
                                        v-if="capSess !== null "
                                        v-for="(tema_, tema_index) in capTemaList"
                                        v-on:click="onCapTemaSelected(tema_)"
                                        :title="'click aqui para editar el tema: ' + tema_.nombre"
                                        :class="'schedule-item bd-l bd-2 ' +( view.capTema_selected !== null && view.capTema_selected !== undefined && view.capTema_selected.idCapTema === tema_.idCapTema ? 'bd-warning active-tema' : 'bd-primary' )">
                                        <h6> {{ tema_.nombre }}</h6>
                                        <span>{{ tema_.descripcion }}</span>
                                    </a><!-- schedule-item -->
                                </div>
                            </div>
                        </div><!-- card-body -->
                    </div><!-- card -->
                    <button type="button" v-if="capTemp.estatus === 1" class="btn btn-sm btn-block btn-danger"   title="Eliminar session"  v-on:click="onCapSessDelete()" id="btn_session_delete"><i class="typcn typcn-trash"></i>Eliminar esta sesión</button>
                </div><!-- col -->
                <div class="col-4" v-if="capSess != null && capSess.eliminada === false">
                    <div class="card mg-b-20 mg-lg-b-5"  v-if="view.addTema === true && capTemp.estatus === 1" >
                        <div class="card-body pd-l-25 pd-r-25 row">
                            <div class="col-12"><a class=" float-right tx-warning" title="Cerrar este formulario" v-on:click="view.addTema = false"><i class="typcn typcn-times"></i></a></div>
                            <h5 class="col-12">Agregar tema</h5>
                            <div class="form-group mt-2 col-12" style="margin-bottom: 1px !important">
                                <label for="capTema_nombre" class="">Nombre </label>
                                <textarea  class="form-control form-control-sm" id="capTema_nombre" maxLength="200" v-model="capTema.nombre" placeholder="Nombre del tema" rows="3"></textarea>
                                <span class="tx-danger tx-10 col-sm-12 text-right">{{ (200 - capTema.nombre.length) + ' / 200' }}</span>
                            </div><!-- form-group -->
                            <div class="form-group  col-12" style="margin-bottom: 1px !important">
                                <label for="captema_descripcion" class="">Descripcion</label>
                                <textarea  class="form-control form-control-sm" id="captema_descripcion" maxLength="300" v-model="capTema.descripcion" placeholder="Descripcion" rows="7"></textarea>
                                <span class="tx-danger tx-10 col-sm-12 text-right">{{ (300 - capTema.descripcion.length) + ' / 300' }}</span>
                            </div><!-- form-group -->
                            <div class="form-group  col-12 mg-b-0 mt-4">
                                <div class="col-sm-12 text-right">
                                    <button type="button" class="btn btn-sm btn-primary btn-block" :disabled="capTema.nombre === ''"  title="Agregar tema"  v-on:click="onCapTemaCreate()" id="btn_tema_add">Agregar <i class="typcn typcn-document-add"></i></button>
                                </div>
                            </div><!-- form-group -->
                        </div><!-- card-body -->
                    </div><!-- card -->
                    <div class="card mg-b-20 mg-lg-b-5"  v-if="view.capTema_selected !== null && view.capTema_selected !== undefined && capTemp.estatus === 1">
                        <div class="card-body pd-l-25 pd-r-25 row">
                            <div class="col-12"><a class=" float-right tx-warning" title="Cerrar este formulario" v-on:click="view.capTema_selected = null"><i class="typcn typcn-times"></i></a></div>
                            <h5 class="col-12">Editar tema</h5>
                            <div class="form-group mt-2 col-12" style="margin-bottom: 1px !important">
                                <label for="capTema_nombre" class="">Nombre </label>
                                <textarea  class="form-control form-control-sm" id="capTema_nombre" maxLength="200" v-model="view.capTema_selected.nombre" placeholder="Nombre del tema" rows="3"></textarea>
                                <span class="tx-danger tx-10 col-sm-12 text-right">{{ (200 - view.capTema_selected.nombre.length) + ' / 200' }}</span>
                            </div><!-- form-group -->
                            <div class="form-group  col-12" style="margin-bottom: 1px !important">
                                <label for="captema_descripcion" class="">Descripcion</label>
                                <textarea  class="form-control form-control-sm" id="captema_descripcion" maxLength="300" v-model="view.capTema_selected.descripcion" placeholder="Descripcion" rows="7"></textarea>
                                <span class="tx-danger tx-10 col-sm-12 text-right">{{ (300 - view.capTema_selected.descripcion.length) + ' / 300' }}</span>
                            </div><!-- form-group -->
                            <div class="form-group  col-12 mg-b-0 mt-4">
                                <div class="btn-group col-12" role="group" aria-label="Basic example">
                                    <button type="button" class="btn btn-sm btn-danger"   title="Eliminar tema"  v-on:click="onCapTemaDelete()" id="btn_tema_del"><i class="typcn typcn-trash"></i></button>
                                    <button type="button" class="btn btn-sm btn-dark btn-block" :disabled="view.capTema_selected.nombre === ''"  title="Actualizar tema"  v-on:click="onCapTemaUpdate()" id="btn_tema_add">Actualizar <i class="typcn typcn-arrow-sync"></i></button>
                                </div>
                            </div><!-- form-group -->
                        </div><!-- card-body -->
                    </div><!-- card -->
                </div><!-- col -->
            </div><!-- col -->
        </div>
    `,
    data: function () {
        return {
            error_DarkUI_exception: null,
            capSess: null,
            capTemp: null,
            capTemaList: [],
            capTema: {
                nombre: '',
                descripcion: '',
            },
            view: {
                editSess: false,
                addTema: false,
                capTema_selected: null
            }
        }
    },
    watch: {
        $route(to, from) {
            this.onCapSessDetails();
            this.onCapTemplDetails();
        }
    },
    mounted() {
        this.onCapSessDetails();
        this.onCapTemaBySession();
        this.onCapTemplDetails();
    },
    methods: {
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapTemplDetails: async function () {
            await axios.get('../FormacionCapacitacion/CapTemplDetails?id=' + this.$route.params.idCapTempl + '&IdVersion=' + this.$route.params.idVersion, null, null).then(response => {
                this.capTemp = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapSessDelete: async function () {
            try {
                await Swal.fire({
                    title: '¿Deseas eliminar esta sesión del diseño?',
                    text: "No podras revertir este cambio!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Si, adelante!'
                }).then(async (result) => {
                    if (!result.isConfirmed) {
                        throw new DarkUI_exception('proceso cancelado', '', true);
                    }
                })

                btn_loading('btn_session_delete', '<i class="typcn typcn-trash"></i>Eliminando esta sesión...')
                let formData = new FormData();
                formData.append("idVersion", this.$route.params.idVersion)
                formData.append("IdCapTempl", this.$route.params.idCapTempl)
                formData.append("IdRefer", this.$route.params.idCapSess)
                formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
                await axios.post('../FormacionCapacitacion/CapSessDelete', formData, null).then(response => {
                    //// agregar la pregunta a la lista
                    ShowMessageErrorShort('Session eliminada', 'success')
                    btn_loading('btn_session_delete', '<i class="typcn typcn-trash"></i>Eliminar esta sesión', 'hide')
                    this.capSess.eliminada = true
                }).catch(error => {
                    btn_loading('btn_session_delete', '<i class="typcn typcn-trash"></i>Eliminar esta sesión', 'hide')
                    GlobalValidAxios(error);
                }).finally(() => {
                })

            } catch (e) {
                console.log(e)
            }
        },
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapTemaDelete: async function () {
            try {
                await Swal.fire({
                    title: 'Estas seguro?',
                    text: "No podras revertir este cambio!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Si, adelante!'
                }).then(async (result) => {
                    if (!result.isConfirmed) {
                        throw new DarkUI_exception('proceso cancelado', '', true);
                    }
                })

                btn_loading('btn_tema_del', '<i class="typcn typcn-trash"></i>Eliminando..')
                let formData = new FormData();
                formData.append("IdCapTempl", this.$route.params.idCapTempl)
                formData.append("idVersion", this.$route.params.idVersion)
                formData.append("IdCapSess", this.$route.params.idCapSess)
                formData.append("IdCapTema", this.view.capTema_selected.idCapTema)
                formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
                await axios.post('../FormacionCapacitacion/CapTemaDelete', formData, null).then(response => {
                    //// agregar la pregunta a la lista
                    ShowMessageErrorShort('Tema eliminado', 'success')
                    var tema = this.capTemaList.findIndex(a => a.idCapTema === this.view.capTema_selected.idCapTema)
                    this.capTemaList.splice(tema, 1)
                    this.view.capTema_selected = null;
                }).catch(error => {
                    GlobalValidAxios(error);
                }).finally(() => {
                })

            } catch (e) {
                console.log(e)
            }


        },
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapTemaSelected: function (captema) {
            this.view.capTema_selected = JSON.parse(JSON.stringify(captema))
        },
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapTemaUpdate: async function () {
            try {

                if (this.view.capTema_selected.nombre === '')
                    throw new DarkUI_exception('Por favor introduce un nombre valido para el tema a actualizar', '');


                btn_loading('btn_tema_add', 'Guardar')
                let formData = new FormData();
                formData.append("IdCapTempl", this.$route.params.idCapTempl)
                formData.append("idVersion", this.$route.params.idVersion)
                formData.append("IdCapSess", this.$route.params.idCapSess)
                formData.append("IdCapTema", this.view.capTema_selected.idCapTema)
                formData.append("Nombre", this.view.capTema_selected.nombre)

                formData.append("Descripcion", this.view.capTema_selected.descripcion)
                formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
                await axios.post('../FormacionCapacitacion/CapTemaUpdate', formData, null).then(response => {
                    //// agregar la pregunta a la lista
                    ShowMessageErrorShort('Datos guardados', 'success')

                    var tema = this.capTemaList.find(a => a.idCapTema === this.view.capTema_selected.idCapTema)
                    tema.nombre = this.view.capTema_selected.nombre
                    tema.descripcion = this.view.capTema_selected.descripcion

                }).catch(error => {
                    GlobalValidAxios(error);
                }).finally(() => {
                    btn_loading('btn_tema_add', 'Actualizar <i class="typcn typcn-arrow-sync"></i>', 'hide')
                })
            } catch (e) {
                this.error_DarkUI_exception = e
                $.alert({
                    title: 'Opps!',
                    content: e.message,
                    type: 'red'
                });
            }
        },
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapTemaCreate: async function () {
            try {

                if (this.capTema.nombre === '')
                    throw new DarkUI_exception('Por favor introduce un nombre valido para el tema a registrar', '');

                if (this.capTemaList.find(a => a.nombre === this.capTema.nombre) !== undefined) {
                    throw new DarkUI_exception('Ya has gregado un tema similar a <strong>' + this.capTema.nombre + '</strong>', '');
                }

                btn_loading('btn_tema_add', 'Guardar')
                let formData = new FormData();
                formData.append("IdCapTempl", this.$route.params.idCapTempl)
                formData.append("idVersion", this.$route.params.idVersion)
                formData.append("IdCapSess", this.$route.params.idCapSess)
                formData.append("Nombre", this.capTema.nombre)
                formData.append("Descripcion", this.capTema.descripcion)
                formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
                await axios.post('../FormacionCapacitacion/CapTemaCreate', formData, null).then(response => {
                    //// agregar la pregunta a la lista
                    ShowMessageErrorShort('Datos guardados', 'success')
                    this.capTemaList.push(response.data)
                    this.capTema.nombre = ''
                    this.capTema.descripcion = ''
                }).catch(error => {
                    GlobalValidAxios(error);
                }).finally(() => {
                    btn_loading('btn_tema_add', 'Guardar', 'hide')
                })
            } catch (e) {
                this.error_DarkUI_exception = e
                $.alert({
                    title: 'Opps!',
                    content: e.message,
                    type: 'red'
                });
            }
        },
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapTemaBySession: async function () {
            await axios.get('../FormacionCapacitacion/CapTemaBySession/?idVersion=' + this.$route.params.idVersion + '&IdCapSess=' + this.$route.params.idCapSess, null, null).then(response => {
                this.capTemaList = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapSessEdit: async function () {
            btn_loading('btn_sessio_update', 'Actualizando.. <i class="typcn typcn-arrow-sync"></i>')
            let formData = new FormData();
            formData.append("IdCapTempl", this.$route.params.idCapTempl)
            formData.append("idVersion", this.$route.params.idVersion)
            formData.append("IdCapSess", this.$route.params.idCapSess)
            formData.append("Nombre", this.capSess.nombre)
            formData.append("Objetivo", this.capSess.objetivo)
            formData.append("Duracion", this.capSess.duracion)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapSessEdit', formData, null).then(async (response) => {
                //// agregar la pregunta a la lista
                ShowMessageErrorShort('Datos guardados', 'success')
                await btn_loading('btn_sessio_update', 'Actualizar <i class="typcn typcn-arrow-sync"></i>', 'hide')
                this.view.editSess = false
            }).catch(error => {
                GlobalValidAxios(error);
                btn_loading('btn_sessio_update', 'Actualizar <i class="typcn typcn-arrow-sync"></i>', 'hide')
            }).finally(() => {
            })

        },
        /**
          * configurar seleccion de tema a editar o eliminar
          * @param {Object} captema
          * @return void
          */
        onCapSessDetails: async function () {
            await axios.get('../FormacionCapacitacion/CapSessDetails/?idVersion=' + this.$route.params.idVersion + '&IdCapTempl=' + this.$route.params.idCapTempl + '&IdCapSess=' + this.$route.params.idCapSess, null, null).then(response => {
                this.capSess = response.data
                //if (this.capSess.eliminada === true) {
                //    ShowMessageErrorShort('Esta sesión fue eliminada', 'warning')
                //    this.$route.push({ name: 'capacitacion-template-admin', params: { idCapSess: this.$route.params.idCapTempl } })
                //}
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
}

Vue.component('card-evaluation', {
    props: ['idCapEva', 'idVersion', 'idCapTemplShedule', 'estatus' ],
    template: `
        <div>
            <div class="row" v-if="estatus === 1"><div class="col-12"><a class=" float-right tx-warning" v-on:click="onCapTemplEvaDel()" title="eliminar esta evaluación" id="btn_del_eva_templ"><i class="typcn typcn-trash tx-danger"></i></a></div></div>
            <div class="media align-items-center mg-b-20" v-if="capEva !== null">
                <div class="wd-45 ht-45 bg-primary rounded d-flex align-items-center justify-content-center">
                    <i class="tx-white-7 wd-20 ht-20 typcn typcn-document"></i>
                </div>
                <div class="media-body pd-l-15">
                    <h6 class="mg-b-3">{{ capEva.nombre }}</h6>
                    <span class="d-block tx-13 tx-color-03">{{ capEva.decripcion }}</span>
                </div>
                <span class="d-none d-sm-block tx-12 tx-color-03 align-self-start"></span>
            </div><!-- media -->
            <p class="mg-b-20" v-if="capEva !== null" >
                Resumen de preguntas
            </p>
            <div class="bd bg-gray-50 pd-y-15 pd-x-15 pd-sm-x-20">
                <div class="d-flex">
                  <div class="profile-skillset flex-fill">
                    <h4 class="link-01">{{ capEvaPrgList.filter(a => a.tipo === 'O').length }}</h4>
                    <label>OPCIONALES</label>
                  </div>
                  <div class="profile-skillset flex-fill">
                    <h4 class="link-01">{{ capEvaPrgList.filter(a => a.tipo === 'M').length }}</h4>
                    <label>OPCIONALES(+1)</label>
                  </div>
                  <div class="profile-skillset flex-fill">
                    <h4 class="link-01">{{ capEvaPrgList.filter(a => a.tipo === 'T').length }}</h4>
                    <label>ABIERTAS</label>
                  </div>
                </div>
            </div>
            <a v-on:click="verEva('show')" title="previsualizar esta evaluación" class="linkds">Visualizar Evaluación</a>
            <div class="modal fade" :id="'modal_preview_eva_templ_'+idCapTemplShedule" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-body pd-20 pd-sm-40">
                            <a role="button" class="close pos-absolute t-15 r-15" v-on:click="verEva('hide')">
                                <span aria-hidden="true">&times;</span>
                            </a>
                            <h4>vista previa de evaluacion</h4>
                            <div class="media align-items-center mg-b-20" v-if="capEva !== null">
                                <div class="wd-45 ht-45 bg-primary rounded d-flex align-items-center justify-content-center">
                                    <i class="tx-white-7 wd-20 ht-20 typcn typcn-document"></i>
                                </div>
                                <div class="media-body pd-l-15">
                                    <h6 class="mg-b-3">{{ capEva.nombre }}</h6>
                                    <span class="d-block tx-13 tx-color-03">{{ capEva.decripcion }}</span>
                                </div>
                                <span class="d-none d-sm-block tx-12 tx-color-03 align-self-start"></span>
                            </div><!-- media -->
                            <div class="schedule-group ">
                                <div v-for="(preg, preg_index) in capEvaPrgList" class="schedule-item bd-l bd-2 bd-success">
                                    <h6>[{{ preg.idCapEvaPrg }}] {{ preg.pregunta }}</h6>
                                    <span>Puntaje: {{ preg.puntaje }}</span>
                                    <span>{{ preg.c }}</span>
                                    <div class="col-lg-12" v-if="preg.tipo !== 'T'">
                                        <ul class="pd-l-10 mg-0  tx-13">
                                            <li v-if="preg.capEvaPrgList !== undefined && preg.capEvaPrgList !== null" v-for="(resp, resp_index) in preg.capEvaPrgList" :class="(resp.esCorrecta ? '' : '') + ' '">[{{ resp.idCapEvaPrgRes }}] {{ resp.respuesta }}</li>
                                        </ul>
                                    </div>
                                    <div v-if="preg.tipo === 'T'" class="bd bg-gray-50 pd-y-15 pd-x-15 pd-sm-x-20 col-12">
                                        <h6 class="tx-15 mg-b-3">Pregunta abierta al usuario</h6>
                                    </div>
                                </div>
                            </div>
                        </div><!-- modal-body -->
                    </div><!-- modal-content -->
                </div><!-- modal-dialog -->
            </div><!-- modal -->
        </div>
    `,
    data: function () {
        return {
            capEva: null,
            capEvaPrgList: []
        }
    },
    mounted() {
        this.getCapEvaPrgList()
        this.getCapEvaDetails()

        
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {
    },
    methods: {
        verEva: function (mode) {
            if (mode === "show") {
                $("#modal_preview_eva_templ_" + this.idCapTemplShedule).modal({
                    backdrop: "static", //remove ability to close modal with click
                    keyboard: false, //remove option to close with keyboard
                    show: true //Display loader!
                });
            } else {
                $("#modal_preview_eva_templ_" + this.idCapTemplShedule).modal("hide")
            }
        },
        onCapTemplEvaDel: async function () {
            //(int IdCapTempl, int IdVersion, int IdEvaCap, int IdCapTemplShedule)
            btn_loading('btn_del_eva_templ', 'Eliminando...')
            let formData = new FormData();
            formData.append("IdCapTempl", this.$route.params.idCapTempl)
            formData.append("idVersion", this.$route.params.idVersion)
            formData.append("IdEvaCap", this.idCapEva)
            formData.append("IdCapRegistryVersionDet", this.idCapTemplShedule)
            formData.append("__RequestVerificationToken", document.querySelector("input[name='__RequestVerificationToken']").value)
            await axios.post('../FormacionCapacitacion/CapTemplEvaDel', formData, null).then(response => {
                this.$emit('goto_deleteEva');
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {
            })
        },
        getCapEvaPrgList: async function () {
            await axios.get('../FormacionCapacitacion/capEvaPrgList?IdVersion=' + this.idVersion + '&IdCapEva=' + this.idCapEva, null, {
                onUploadProgress: function (progressEvent) {
                    console.log("asdasdadadasdas: ")
                }
            }).then(response => {
                this.capEvaPrgList = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        getCapEvaDetails: async function () {
            await axios.get('../FormacionCapacitacion/CapEvaDetails?IdVersion=' + this.idVersion + '&IdCapEva=' + this.idCapEva, null, null).then(response => {
                this.capEva = response.data.eva
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
})
// details component session
Vue.component('card-session', {
    props: ['id', 'shedule', 'idVersion', 'estatus'],
    template: `
    <div>
        <div class="row"><div class="col-12"><a class=" float-right tx-warning" v-on:click="$emit('goto_details')" title="ir a detalles"><i class="typcn typcn-eye"></i></a></div></div>
        
        <dl class="row" style="font-size: 13px;" v-if="capSess !== null">
            <dt class="col-12">
                Nombre
            </dt>
            <dd class="col-12">
                 {{ capSess.nombre }}
            </dd>
            <dt class="col-12">
                Objetivo
            </dt>
            <dd class="col-12">
                {{ capSess.objetivo }}
            </dd>
            <dt class="col-12">
                Duración
            </dt>
            <dd class="col-12">
                {{ capSess.duracion }} hrs
            </dd>
            <dt class="col-12" v-if="capSess.eliminada === true">
                Estatus
            </dt>
            <dd class="col-12" v-if="capSess.eliminada === true">
                <span class='badge badge-danger'>Eliminada</span>
            </dd>
        </dl>
        <ul v-for="(tema_, tema_index) in capTemaList" class="pd-l-10 mg-0 mg-t-2 tx-13">
            <li>{{ tema_.nombre }}</li>
        </ul>
    </div>
    `,
    data: function () {
        return {
            data: this.shedule,
            capSess: null,
            capTemaList: []
        }
    },
    mounted() {
        console.log("version: " + this.idVersion + " ref: " + this.data.idRefer)
        this.onCapSessDetails()
        this.onCapTemaBySession()
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {
        console.log({ key, target, type })
    },
    methods: {
        onCapTemaBySession: async function () {
            await axios.get('../FormacionCapacitacion/CapTemaBySession/?idVersion=' + this.idVersion + '&IdCapSess=' + this.data.idRefer, null, null).then(response => {
                this.capTemaList = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        },
        onCapSessDetails: async function () {
            await axios.get('../FormacionCapacitacion/CapSessDetails/?idVersion=' + this.idVersion + '&IdCapTempl=' + this.data.idCapTempl + '&IdCapSess=' + this.data.idRefer, null, null).then(response => {
                this.capSess = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {

            })
        }
    }
})


// 0. If using a module system (e.g. via vue-cli), import Vue and VueRouter
// and then call `Vue.use(VueRouter)`.

// 1. Define route components.
// These can be imported from other files
const Foo = { template: '<div>foo</div>' }
const Bar = { template: '<div>bar</div>' }

// 2. Define some routes
// Each route should map to a component. The "component" can
// either be an actual component constructor created via
// `Vue.extend()`, or just a component options object.
// We'll talk about nested routes later.
const routes = [
    {
        path: '/',
        component: Foo,
        redirect: { name: 'capacitacion-template-list' },
    },
    {
        path: '/Evaluaciones',
        name: 'evaluaciones-data',
        component: EvaList,
        children: [
            {
                name: 'evaluacion-details',
                path: 'Detalle/:idCapEva',
                component: EvaDetails,
                //redirect: { name: 'evaluacion-preguntas' }, 
                children: [
                    {
                        name: 'evaluacion-preguntas',
                        path: ':idCapRegistryVersion/admin',
                        component: EvaDetailsList
                    },
                    {
                        name: 'evaluacion-addPreg',
                        path: 'pregunta/agregar',
                        component: EvaPregAdd
                    },
                    {
                        name: 'evaluacion-editPreg',
                        path: 'pregunta/:idCapEvaPrg/editar',
                        component: EvaPregEdit
                    }
                ]
            }
        ]
    },
    {
        path: '/Template',
        name: 'capacitacion-template-list',
        component: template,
    },
    {
        name: 'capacitacion-template-admin',
        path: '/Template/:idCapTempl/admin/:idVersion',
        component: template_admin,
        children: [
            {
                name: 'admin-session-edit',
                path: 'session/:idCapSess/edit',
                component: CapTemplSessEdit
            }
        ]
    }
]

// 3. Create the router instance and pass the `routes` option
// You can pass in additional options here, but let's
// keep it simple for now.
const router = new VueRouter({
    routes, // short for `routes: routes`
})

// 4. Create and mount the root instance.
// Make sure to inject the router with the router option to make the
// whole app router-aware.
const app = new Vue({
    router
}).$mount('#app')

// Now the app has started!