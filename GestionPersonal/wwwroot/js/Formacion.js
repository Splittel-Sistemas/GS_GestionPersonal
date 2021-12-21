var BtnSpinner = class {
    constructor(element) {
        this.button = element
        this.oldContent = element.innerHTML

        this.start()
    }

    start() {
        this.button.innerHTML = `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true""></span>`
    }

    complete() {
        this.button.innerHTML = this.oldContent

    }
}



//datetime_calendar
Vue.filter('datetime_calendar', function (value) {
    if (!value) return '---'

    moment.locale('es-mx');
    return moment(value).calendar();
})
//capacitacion - programas
Vue.component('capacitacion-programas', {
    props: [],
    template: `
<div class="pd-y-20 pd-x-10 contact-list">
    <label class="contact-list-divider">Recently Contacted</label>
    <div class="media">
        <div class="avatar avatar-sm avatar-online"><img src="../https://via.placeholder.com/500" class="rounded-circle" alt=""></div>
        <div class="media-body mg-l-10">
            <h6 class="tx-13 mg-b-3">Camille Audrey</h6>
            <span class="tx-12">+1-234-567-890</span>
        </div><!-- media-body -->
        <nav>
            <a href=""><i class="fas fa-swatchbook"></i></a>
            <a href=""><i class="fas fa-swatchbook"></i></a>
        </nav>
    </div><!-- media -->
    <div class="media">
        <div class="avatar avatar-sm avatar-offline"><span class="avatar-initial rounded-circle bg-success">E</span></div>
        <div class="media-body mg-l-10">
            <h6 class="tx-13 mg-b-3">Elvis Vircede</h6>
            <span class="tx-12">+63929-123-4567</span>
        </div><!-- media-body -->
        <nav>
            <a href=""><i class="fas fa-swatchbook"></i></a>
            <a href=""><i class="fas fa-swatchbook"></i></a>
        </nav>
    </div><!-- media -->
</div><!-- contact-list -->
    `,
    data: function () {
        return {
            info: '',
            capTemaList: []
        }
    },
    async mounted() {
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onCapTemaBySession: async function () {
            //this.capTemaList = []
            //await axios.get(`../FormacionCapacitacion/CapTemaBySession?idVersion=${this.idVersion}&IdCapSess=${this.idCapSess}`, null, null).then(response => {
            //    this.capTemaList = response.data
            //}).catch(error => {
            //    GlobalValidAxios(error);
            //}).finally(() => {

            //})
        },
    }
})
//capacitacion - templates
Vue.component('capacitacion-templates', {
    props: [],
    template: `
<div>
    <div class="placeholder-paragraph ml-2 mt-2" v-if="loadding === true">
        <div class="line"></div>
        <div class="line"></div>
    </div>
    <div class="pd-y-20 pd-x-10 contact-list" v-if="loadding === false && formaciones.length > 0">
        <div v-for="(formacion, formacion_index) in formaciones" :class="'media ' + (parseInt($route.params.idCF_Formacion) === formacion.idCF_Formacion ? 'active' : '' )"  :key="'eva_' + formacion.idCF_Formacion">
            <div class="media-body mg-l-10">
                <h6 class="tx-13 mg-b-3">{{ formacion.folio }}</h6>
                <span class="tx-12">{{ formacion.nombre | reducir }}</span>
            </div><!-- media-body -->
            <nav>
                <router-link :to="{ name: 'admin-formacion-design', params: { idCF_Formacion : formacion.idCF_Formacion }}" title="ver esta capacitacion">
                    <i class="fas fa-swatchbook"></i>
                </router-link>
            </nav>
        </div><!-- media -->
    </div><!-- contact-list -->
    <div v-if="loadding === false && formaciones.length <= 0" class="content content-fixed content-auth-alt mt-5">
        <div class="container ht-100p tx-center mt-5">
            <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                <h4 class="tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5">Sin diseños</h4>
            </div>
        </div><!-- container -->
    </div><!-- content -->
</div>

    `,
    data: function () {
        return {
            info: '',
            formaciones: [],
            loadding: false
        }
    },
    async mounted() {
        this.onCapTemaBySession();
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {

    },
    computed: {
        addNew: function (elemt) {
            console.log(elemt)
        }
    },
    methods: {
        onCapTemaBySession: async function () {
            this.loadding = true
            this.formaciones = []
            await axios.get(`../v2/api/Formacion/ListFormaciones`, null, null).then(response => {
                this.formaciones = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {
                this.loadding = false
            })
        },
    },
    filters: {
        reducir: function (cadena) {
            return cadena.length > 100 ? cadena.substring(0, 100) + "..." : cadena;
        }
    }
})
//formacion - btn - add
Vue.component('formacion-btn-add', {
    props: [],
    template: `
<div>
    <a class="btn btn-xs btn-icon btn-primary tx-white" v-on:click="openModalAdd()">
        <span data-toggle="tooltip" title="Agregar nueva formación"><i class="icon ion-md-add tx-white"></i></span>
    </a><!-- contact-add -->
    <div class="modal fade effect-scale" id="modalNewContact" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body pd-20 pd-sm-30">
                    <button type="button" class="close pos-absolute t-15 r-20" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                    <h5 class="tx-18 tx-sm-20 mg-b-20">Crear nueva formación</h5>
                    <p class="tx-13 tx-color-03 mg-b-30">
                        Por favor introduce la siguiente información para crear una nueva formacion,
                    </p>

                    <div class="d-sm-flex">
                        <div class="flex-fill">
                            <api-result class="mt-2 mb-2" v-if="proccess.api_proc_add !== null" :response_api="proccess.api_proc_add"></api-result>
                            <div class="form-group mg-b-10">
                                <label>Nombre</label>
                                <input type="text" class="form-control" placeholder="Nombre de la formación" v-model="formacion.nombre">
                            </div><!-- form-group -->
                            <div class="form-group mg-b-10">
                                <label>Descripción</label>
                                <textarea class="form-control" rows="2" placeholder="Agrega tu descripción" v-model="formacion.descripcion"></textarea>
                            </div><!-- form-group -->
                        </div><!-- col -->
                        
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="wd-100p d-flex flex-column flex-sm-row justify-content-end">
                        <button type="button" class="btn btn-secondary mg-sm-l-5" data-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary mg-b-5 mg-sm-b-0" :disabled="formacion.nombre.trim() === '' || formacion.descripcion.trim() === ''" v-on:click="onAddFormacion()">Guardar</button>
                    </div>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>
    `,
    data: function () {
        return {
            info: '',
            formacion: {
                nombre: '',
                descripcion: '',
                activa: false
            },
            proccess: {
                api_proc_add: null
            }
        }
    },
    async mounted() {
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        openModalAdd: function () {
            this.proccess.api_proc_add = null;
            this.formacion.nombre = ''
            this.formacion.descripcion = ''
            $("#modalNewContact").modal({
                backdrop: false, //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
            //$('.modal-backdrop').remove();
        },
        onAddFormacion: async function () {
            this.proccess.api_proc_add = {
                loadding: true
            }
            await axios.post(`../v2/api/Formacion/AddFormacion`, this.formacion, null).then(response => {
                this.proccess.api_proc_add = {
                    loadding: false,
                }
                this.$emit('addNew', response.data)
                $("#modalNewContact").modal("hide")
            }).catch(error => {
                this.proccess.api_proc_add = {
                    loadding: false,
                    response_error: error
                }
            }).finally(() => {

            })
        },
    }
})
//api - result
Vue.component('api-result', {
    props: ['response_api'],
    template: `
        <div>
            <h1 v-if="response_api_.loadding">Cargando</h1>
            <div v-if="response_api_.loadding === false" :class="'alert mg-b-0 alert-' + renderHtml().classname " role="alert" v-html="renderHtml().text">
            </div>
        </div>
    `,
    data: function () {
        return {
            response_api_: this.response_api,
        }
    },
    async mounted() {
    },
    watch: {
        response_api: function (newVal, oldVal) {
            this.response_api_ = newVal
        }
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        renderHtml: function () {
            let sms_val = {
                classname: '',
                text: ''
            }
            if (this.response_api_.response_error) {
                if (this.response_api_.response_error.response) {
                    sms_val.text = "error api";
                    sms_val.classname = "warning";
                }
                else {
                    sms_val.text = "Oops! Algo ha ocurrido, intenta de nuevo";
                    sms_val.classname = "danger";
                }
            } else {
                sms_val.text = "Proceso completo";
                sms_val.classname = "success";
            }

            return sms_val
        }
    }
})
//formacion-actions
Vue.component('formacion-actions', {
    props: ['idCF_Formacion'],
    template: `
<div>
    <div class="contact-content-sidebar" v-if="formacion !== null">
        
        <h5 id="contactName" class="tx-18 tx-xl-20 mg-b-5">{{ formacion.folio }}</h5>
        <p class="tx-13 tx-lg-12 tx-xl-13 tx-color-03 mg-b-20">{{ formacion.nombre }}</p>

        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Descripción</label>
        <p class="tx-13 mg-b-0">
            {{ formacion.descripcion }}
        </p>

        <hr class="mg-y-20">

        <nav class="nav flex-column contact-content-nav mg-b-25 mt-3 mb-3">
            <a class="nav-link" data-toggle="tooltip" title="Capacitacion activa" v-if="formacion.activa"><i class="fas fa-arrow-up"></i> Capacitacion activa</a>
            <a class="nav-link" data-toggle="tooltip" title="Capacitacion inactiva" v-if="!formacion.activa"><i class="fas fa-arrow-down"></i> Capacitacion inactiva</a>
        </nav>

        <button class="btn btn-sm btn-white btn-block" v-on:click="beforeUpdateFormacion">Editar <i class="fas fa-pen"></i></button>

    </div><!-- contact-content-sidebar -->
    <div class="modal fade effect-scale" id="moda_edit_formacion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document" v-if="formacion !== null">
            <div class="modal-content">
                <div class="modal-body pd-20 pd-sm-30">
                    <button type="button" class="close pos-absolute t-15 r-20" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                    <h5 class="tx-18 tx-sm-20 mg-b-20">Editar formación</h5>
                    <p class="tx-13 tx-color-03 mg-b-30">
                        Por favor introduce la siguiente información,
                    </p>

                    <div class="d-sm-flex">
                        <div class="flex-fill">
                            <api-result class="mt-2 mb-2" v-if="proccess.api_form_edit !== null" :response_api="proccess.api_form_edit"></api-result>
                            <div class="form-group mg-b-10">
                                <label>Nombre</label>
                                <textarea class="form-control" rows="4" placeholder="Agrega tu descripción" v-model="formacion_updModel.nombre"></textarea>
                            </div><!-- form-group -->
                            <div class="form-group mg-b-10">
                                <label>Descripción</label>
                                <textarea class="form-control" rows="15" placeholder="Agrega tu descripción" v-model="formacion_updModel.descripcion"></textarea>
                            </div><!-- form-group -->
                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" id="customCheck1" v-model="formacion_updModel.activa">
                                <label class="custom-control-label" for="customCheck1">Activar capacitación</label>
                            </div>
                        </div><!-- col -->

                    </div>
                </div>
                <div class="modal-footer">
                    <div class="wd-100p d-flex flex-column flex-sm-row justify-content-end">
                        <button type="button" class="btn btn-secondary mg-sm-l-5" data-dismiss="modal" v-on:click="onCancelUpdate">Cancelar</button>
                        <button type="button" class="btn btn-primary mg-b-5 mg-sm-b-0 ml-2" :disabled="formacion_updModel.nombre.trim() === '' || formacion_updModel.descripcion.trim() === ''" v-on:click="onUpdateFormacion">Guardar</button>
                    </div>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>
    `,
    data: function () {
        return {
            formacion: null,
            formacion_updModel: null,
            proccess: {
                api_form_edit: null
            }
        }
    },
    async mounted() {
        await this.onDetailsFormacion();
        new PerfectScrollbar('.contact-content-sidebar', {
            suppressScrollX: true
        });
    },
    watch: {
        idCF_Formacion: function (newVal, oldVal) {
            this.onDetailsFormacion();
        }
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onCancelUpdate: function () {
            this.formacion_updModel = {
                idCF_Formacion: this.formacion.idCF_Formacion,
                nombre: this.formacion.nombre,
                descripcion: this.formacion.descripcion,
                activa: this.formacion.activa,
            }
        },
        onUpdateFormacion: async function () {
            this.proccess.api_form_edit = {
                loadding: true
            }
            
            await axios.put(`../v2/api/Formacion/UpdateFormacion?IdCF_Formacion=${this.idCF_Formacion}`, this.formacion_updModel, null).then(response => {
                this.proccess.api_form_edit = null
                $("#moda_edit_formacion").modal("hide")
                this.formacion.idCF_Formacion = this.formacion_updModel.idCF_Formacion
                this.formacion.nombre = this.formacion_updModel.nombre
                this.formacion.descripcion = this.formacion_updModel.descripcion
                this.formacion.activa = this.formacion_updModel.activa
            }).catch(error => {
                this.proccess.api_form_edit = {
                    loadding: false,
                    response_error: error
                }
            }).finally(() => {
                formacion_updModel = null;
            })
        },
        beforeUpdateFormacion: function () {
            $("#moda_edit_formacion").modal({
                backdrop: false, //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onDetailsFormacion: async function () {
            this.formacion = null
            await axios.get(`../v2/api/Formacion/DetailsFormacion?IdCF_Formacion=${this.idCF_Formacion}`, null, null).then(response => {
                this.formacion = response.data
                this.formacion_updModel = {
                    idCF_Formacion: response.data.idCF_Formacion,
                    nombre: response.data.nombre,
                    descripcion: response.data.descripcion,
                    activa: response.data.activa,
                }
            }).catch(error => {
                
            }).finally(() => {

            })
        }
    }
})
//version - btn - add
Vue.component('version-btn-add', {
    props: ['idCF_Formacion'],
    template: `
<div>
    <a class="text-secondary mg-l-auto" v-on:click="openModalAdd()" >
        <span data-toggle="tooltip" title="Nueva version"><i class="fas fa-sitemap"></i></span>
    </a><!-- contact-add -->
    <div class="modal fade effect-scale" id="modalNewversion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body pd-20 pd-sm-30">
                    <button type="button" class="close pos-absolute t-15 r-20" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                    <h5 class="tx-18 tx-sm-20 mg-b-20">Crear nueva versión</h5>
                    <p class="tx-13 tx-color-03 mg-b-30">
                        Por favor introduce la siguiente información para crear una nueva versión,
                    </p>

                    <div class="d-sm-flex">
                        <div class="flex-fill">
                            <api-result class="mt-2 mb-2" v-if="proccess.api_proc_add !== null" :response_api="proccess.api_proc_add"></api-result>
                            <div class="form-group mg-b-10">
                                <label>Comentarios</label>
                                <textarea class="form-control" rows="2" placeholder="Agrega tu descripción" v-model="version.comentarios"></textarea>
                            </div><!-- form-group -->
                        </div><!-- col -->
                        
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="wd-100p d-flex flex-column flex-sm-row justify-content-end">
                        <button type="button" class="btn btn-secondary mg-sm-l-5" data-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary mg-b-5 mg-sm-b-0  ml-2" :disabled="version.comentarios.trim() === ''" v-on:click="onAddFormacion()" id="add_new_version">Guardar</button>
                    </div>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>
    `,
    data: function () {
        return {
            info: '',
            version: {
                comentarios: '',
                idCF_Formacion: parseInt(this.idCF_Formacion),
                activa: false,
                noVersion: 1
            },
            proccess: {
                api_proc_add: null
            }
        }
    },
    async mounted() {
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        openModalAdd: function () {
            this.proccess.api_proc_add = null;
            this.version.comentarios = ''
            $("#modalNewversion").modal({
                backdrop: false, //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
            //$('.modal-backdrop').remove();
        },
        onAddFormacion: async function () {
            this.proccess.api_proc_add = {
                loadding: true
            }
            this.version.idCF_Formacion = parseInt(this.idCF_Formacion)
            btn_loading("add_new_version", 'Guardando')
            await axios.post(`../v2/api/Formacion/AddVersion/${this.idCF_Formacion}`, this.version, null).then(response => {
                btn_loading("add_new_version", 'Guardar', 'hide')
                this.proccess.api_proc_add = {
                    loadding: false,
                }
                this.$emit('addNew', response.data)
                $("#modalNewversion").modal("hide")
            }).catch(error => {
                btn_loading("add_new_version", 'Guardar', 'hide')
                this.proccess.api_proc_add = {
                    loadding: false,
                    response_error: error
                }
            }).finally(() => {
                
            })
        },
    }
})
// version-edit-page
Vue.component('version-edit-page', {
    props: ['idCF_Formacion', 'idCF_Version', 'idCF_PaginaContent', 'publicada'],
    template: `
<div style="height: 100%;">
    <div class="d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30">
        <div>
            <nav aria-label="breadcrumb">
            
            </nav>
        </div>
        <div class="d-none d-md-block">
            
            <button class="btn btn-sm pd-x-15 btn-white btn-uppercase" v-on:click="onDeleteContenido" data-toggle="tooltip" title="Eliminar este contenido"><i class="fas fa-trash"></i></button>
            <button class="btn btn-sm pd-x-15 btn-white btn-uppercase" v-on:click="onUpdateContenido" data-toggle="tooltip" title="Guardar cambios"><i class="fas fa-save"></i></button>
        </div>
    </div>
    <div class="mb-3" v-if="publicada == true && page !== null">
        {{ page.nombrePage }}
        <hr>
    </div>
    <div ref="editor_container" >
        <div ref="editor_body" :id="'container_' + idCF_PaginaContent">
        </div>
    </div>
</div>
    `,
    data: function () {
        return {
            info: '',
            page: null,
            editorHTML: null,
            contentHTML: ''
        }
    },
    async mounted() {
        
        await this.onDetailsVersion();
        await this.onDetailsVersionPageHTML();
        this.startEditor();

        //this.editorHTML.root.innerHTML = this.contentHTML
        
    },
    watch: {
        idCF_Formacion: function (newVal, oldVal) {
            this.onDetailsVersion();
        },
        idCF_Version: function (newVal, oldVal) {
            this.onDetailsVersion();
        },
        idCF_PaginaContent: function (newVal, oldVal) {
            this.onDetailsVersion();
        },
        publicada: function (newVal, oldVal) {
            console.log(newVal)
            /*this.editorHTML.enable(!newVal);*/

            if (newVal) {
                this.$refs.editor_body.innerHTML = this.contentHTML
            }

        }
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        startEditor: function () {
            // reply form
            this.editorHTML = GlobalQuill(this.$refs.editor_body);
            this.editorHTML.root.innerHTML = this.contentHTML
        },
        createFile: function () {
            //console.log(this.editorHTML)
        },
        onDetailsVersion: async function () {
            this.page = null
            await axios.get(`../v2/api/Formacion/DetailsContenido?IdCF_Version=${this.idCF_Version}&CF_PaginaContent=${this.idCF_PaginaContent}`, null, null).then(response => {
                this.page = response.data
                this.onDetailsVersionPageHTML();
            }).catch(error => {

            }).finally(() => {

            })
            this.$emit("updateNamePage", this.page)
        },
        onDetailsVersionPageHTML: async function () {
            if (this.page.filePath !== '' && this.page.filePath !== null) {
                await axios.get(`../${this.page.filePath}`, null, null).then(response => {
                    //this.editorHTML.root.innerHTML = response.data
                    this.contentHTML = response.data
                }).catch(error => {

                }).finally(() => {

                })
            }
        },
        onDeleteContenido: async function (event) {
            let myButton = new BtnSpinner(event.target)
            //myButton.start()
            await axios.delete(`../v2/api/Formacion/DeleteContenido/${this.idCF_Formacion}/${this.idCF_Version}/${this.page.idCF_PaginaContent}`, null, null).then(async (response) => {
                myButton.complete();
                this.$emit("deletePage")
            }).catch(error => {
                myButton.complete();
            }).finally(() => {
                
            })
        },
        onUpdateContenido: async function (event) {
            let myButton = new BtnSpinner(event.target)
            
            let file = new File([this.editorHTML.root.innerHTML], "foo.txt", {
                type: "text/html",
            })
            let contenido = new FormData()
            contenido.append("idCF_PaginaContent", parseInt(this.page.idCF_PaginaContent));
            contenido.append("pageContent", file);
            contenido.append("idCF_Version", parseInt(this.$route.params.idCF_Version));
            contenido.append("nombrePage", this.page.nombrePage);
            contenido.append("noPage", this.page.noPage);
            const config = {
                headers: {
                    'content-type': 'multipart/form-data'
                }
            }
            await axios.put(`../v2/api/Formacion/UpdateContenido/${this.idCF_Formacion}/${this.idCF_Version}/${this.page.idCF_PaginaContent}`, contenido, config).then(response => {
                this.onDetailsVersion();
                this.contentHTML = this.editorHTML.root.innerHTML
            }).catch(error => {

            }).finally(() => {
                myButton.complete();
            })
        },
    }
})
// version-details-page
Vue.component('version-details-page', {
    props: ['idCF_Formacion', 'idCF_Version', 'idCF_PaginaContent', 'publicada'],
    template: `
<div style="height: 100%;">
    <div class="mb-3" v-if="publicada == true && page !== null">
        {{ page.nombrePage }}
        <hr>
    </div>
    <div ref="editor_container" >
        <div ref="editor_body" :id="'container_' + idCF_PaginaContent" v-html="contentHTML">
        </div>
    </div>
</div>
    `,
    data: function () {
        return {
            info: '',
            page: null,
            editorHTML: null,
            contentHTML: ''
        }
    },
    async mounted() {
        await this.onDetailsVersion();
        await this.onDetailsVersionPageHTML();
    },
    watch: {
        idCF_Formacion: async function (newVal, oldVal) {
            await this.onDetailsVersion();
            await this.onDetailsVersionPageHTML();
        },
        idCF_Version: async function (newVal, oldVal) {
            await this.onDetailsVersion();
            await this.onDetailsVersionPageHTML();
        },
        idCF_PaginaContent: async function (newVal, oldVal) {
            await this.onDetailsVersion();
            await this.onDetailsVersionPageHTML();
        },
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {

        onDetailsVersion: async function () {
            this.page = null
            await axios.get(`../v2/api/Formacion/DetailsContenido?IdCF_Version=${this.idCF_Version}&CF_PaginaContent=${this.idCF_PaginaContent}`, null, null).then(response => {
                this.page = response.data
                this.onDetailsVersionPageHTML();
            }).catch(error => {

            }).finally(() => {

            })
            this.$emit("updateNamePage", this.page)
        },
        onDetailsVersionPageHTML: async function () {
            if (this.page.filePath !== '' && this.page.filePath !== null) {
                await axios.get(`../${this.page.filePath}`, null, null).then(response => {
                    //this.editorHTML.root.innerHTML = response.data
                    this.contentHTML = response.data
                }).catch(error => {

                }).finally(() => {

                })
            }
        },
       
    }
})

const not_found = {
    template: `
<div>
    <h1>{{ $route.params.message }}</h1>
</div>
`,
}

const principal = {
    template: `
<div>
    <div class="contact-wrapper">
        <div class="contact-navleft">
            <nav class="nav flex-column">
                <router-link :to="{ name: 'admin-formacion'}" :class="'nav-link active '" >
                    <span data-toggle="tooltip" title="Administrar capacitaciones" data-placement="right"><i class="fas fa-book"></i></span>
                </router-link>
                <router-link :to="{ name: 'admin-evaluacion'}" :class="'nav-link active '" >
                    <span data-toggle="tooltip" title="Administrar evaluaciones" data-placement="right"><i class="fas fa-vials"></i></span>
                </router-link>
            </nav>
        </div><!-- contact-navleft -->
        <router-view></router-view>
    </div><!-- contact-wrapper -->
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
    mounted() {

    },
    methods: {

    }
}

const admin_formacion = {
    template: `
<div>
    <div class="contact-sidebar">
        <div class="contact-sidebar-header">
            <i data-feather="search"></i>
            <div class="search-form">
                <input type="search" class="form-control" placeholder="buscar...">
            </div>
            <formacion-btn-add v-on:addNew="addNew"></formacion-btn-add>
        </div><!-- contact-sidebar-header -->
        <div class="contact-sidebar-body">
            <capacitacion-templates ref="list_formaciones"></capacitacion-templates>
        </div><!-- contact-sidebar-body -->
    </div><!-- contact-sidebar -->
    <router-view></router-view>
</div>
`
    ,
    mounted() {
        new PerfectScrollbar('.contact-sidebar-body', {
            suppressScrollX: true
        });
    },
    methods: {
        addNew: function (newformacion) {
            this.$refs.list_formaciones.formaciones.push(newformacion);
        }
    }
};

const admin_formacion_design = {
    template: `
<div class="contact-content">
    <div class="contact-content-header">
        <nav class="nav">
            <router-link v-for="(version, version_index) in versiones" :key="'version_' + version.idCF_Version" :to="{ name: 'admin-formacion-design-version', params: { idCF_Version : version.idCF_Version, idCF_Formacion: $route.params.idCF_Formacion }}"
                :class="'nav-link ' + (parseInt($route.params.idCF_Version) === version.idCF_Version ? 'active' : '')">
                {{version.folio}} <i class="fas fa-swatchbook"></i>
            </router-link>
        </nav>
        <a href="" id="contactOptions" class="text-secondary mg-l-auto"></a>
        <version-btn-add  class="ml-2" :idCF_Formacion="$route.params.idCF_Formacion" v-on:addNew="addNew"></version-btn-add>
    </div><!-- contact-content-header -->

    <router-view></router-view>
    <formacion-actions :idCF_Formacion="$route.params.idCF_Formacion"></formacion-actions>
    
</div><!-- contact-content -->
    `,
    data: function () {
        return {
            versiones: []
        }
    },
    watch: {
        $route(to, from) {
            if (to.params.idCF_Formacion !== from.params.idCF_Formacion) {
                this.onListVersiones();
            }
        }
    },
    mounted() {
        this.onListVersiones();
    },
    methods: {
        addNew: function (newObj) {
            this.versiones.push(newObj)
        },
        onListVersiones: async function () {
            this.versiones = null
            await axios.get(`../v2/api/Formacion/ListVersiones?IdCF_Formacion=${this.$route.params.idCF_Formacion}`, null, null).then(response => {
                this.versiones = response.data
            }).catch(error => {

            }).finally(() => {

            })
        }
    }
}

const admin_formacion_design_version = {
    template: `
<div class="contact-content-body">
    <div class="tab-content pd-20 pd-xl-25" style="height: auto;">
        <div class="d-flex align-items-center justify-content-between mg-b-30">
            <h6 class="tx-15 mg-b-0" v-if="version !== null && version.publicada === false">Esta versión no ha sido publicada</h6>
            <h6 class="tx-15 mg-b-0" v-if="version !== null && version.publicada === true">Fecha publicacion: {{ version.fechaPubli | datetime_calendar }}</h6>
            
            <div class="btn-group  d-flex" role="group" aria-label="Basic example"  v-if="version !== null">
                <button class="btn btn-sm pd-x-15 btn-white btn-uppercase" v-if="version.publicada === false" data-toggle="tooltip" title="Administrar evaluaciones para este contenido"><i class="fas fa-vials"></i></button>
                <button type="button" class="btn btn-white btn-sm" v-on:click="onPublicarVersion" v-if="version.publicada === false" id="btn_publicar_form">Publicar</button>
                <div class="dropdown dropright">
                    <button class="btn btn-white btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                      <i class="icon ion-md-time mg-r-5 tx-16 lh--9"></i>
                    </button>
                    <div class="dropdown-menu tx-13">
                      <div class="wd-400 pd-15">
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Versión</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.folio }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Comentarios</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.comentarios }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10 mt-2">Fe.Creación</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.createdAt | datetime_calendar }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Fe.Actualización</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.updatedAt  | datetime_calendar }}
                        </p>
                      </div>
                    </div>
                </div>
            </div><!-- btn-group -->
        </div><!-- d-flex -->
        <ul class="nav nav-tabs" id="myTab" role="tablist"  v-if="pages.length > 0">
            <li class="nav-item" v-for="(page, page_index) in pages">
                <a :class="'nav-link '+ (selected === page_index ? 'active' : '')" v-on:click="selected = page_index"  data-toggle="tab" :href="'#tab_'+page.idCF_PaginaContent" role="tab" aria-controls="home" aria-selected="true">{{page.nombrePage}}</a>
            </li>
            <li class="nav-item" v-if="version !== null && version.publicada === false">
                <button class="btn btn-sm btn-primary" data-toggle="tooltip" title="Agregar nueva pagina" id="new_page_content"  v-on:click="onAddContenido">Nuevo</button>
            </li>
        </ul>
        <div class="tab-content bd bd-gray-300 bd-t-0 pd-20" id="myTabContent" style="height: 100%;background: white;" v-if="pages.length > 0 && version !== null">
            <div v-for="(page, page_index) in pages" :class="'tab-pane fade '+ (selected === page_index ? ' show active' : '')" :id="'idtab_'+page.idCF_PaginaContent" role="tabpanel" aria-labelledby="home-tab" style="height: 100%;">
                <version-edit-page
                    v-if="version.publicada === false"
                    :idCF_Formacion="$route.params.idCF_Formacion"
                    :idCF_Version="$route.params.idCF_Version"
                    :idCF_PaginaContent="page.idCF_PaginaContent"
                    v-on:updateNamePage="updateNamePage"
                    :publicada="version.publicada"
                    v-on:deletePage="pages.splice(selected, 1)"
                    >
                </version-edit-page>
                <version-details-page
                    v-if="version.publicada === true"
                    :idCF_Formacion="$route.params.idCF_Formacion"
                    :idCF_Version="$route.params.idCF_Version"
                    :idCF_PaginaContent="page.idCF_PaginaContent"
                    :publicada="version.publicada"
                >
                </version-details-page>
            </div>
        </div>
        <div class="content content-fixed content-auth-alt mt-5"  v-if="pages.length <= 0">
            <div class="container ht-100p tx-center mt-5">
                <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                    <h4 class="tx-color-01 tx-15 tx-sm-23 tx-lg-29 mg-xl-b-5">Sin paginas de contenido</h4>
                    <div class="wd-70p wd-sm-250 wd-lg-500 mg-b-15"><img src="https://ouch-cdn2.icons8.com/l2mWE4hjgAocEqEARVpS-27gLwV2SdIyZtzfUrl3asw/rs:fit:912:912/czM6Ly9pY29uczgu/b3VjaC1wcm9kLmFz/c2V0cy9zdmcvMjMw/L2QwNGUzMGQyLWY2/OTMtNDE0OS05OTI2/LWY5N2UxNWQ4OTUw/My5zdmc.png" class="img-fluid" alt=""></div>
                    <div class="mg-b-40" v-if="version !== null && version.publicada === false">
                        <button class="btn btn-sm btn-primary" data-toggle="tooltip" title="Agregar nueva pagina" id="new_page_content"  v-on:click="onAddContenido">Agregar primer página</button>
                    </div>
                </div>
            </div><!-- container -->
        </div><!-- content -->
    </div><!-- tab-content -->
</div><!-- contact-content-body -->
    `,
    data: function () {
        return {
            version: null,
            pages: [],
            selected: 0
        }
    },
    watch: {
        $route(to, from) {
            if (to.params.idCF_Formacion !== from.params.idCF_Formacion || to.params.idCF_Version !== from.params.idCF_Version) {
                this.onDetailsVersion();
                this.onListContenidos();
            }
        }
    },
    mounted() {
        this.onDetailsVersion();
        this.onListContenidos();
        new PerfectScrollbar('.contact-content-body', {
            suppressScrollX: true
        });
    },
    methods: {
        onPublicarVersion: async function () {
            btn_loading("btn_publicar_form", 'Registrando')
            
            await axios.get(`../v2/api/Formacion/PublicarVersion/${this.$route.params.idCF_Formacion}/${this.$route.params.idCF_Version}`, null, null).then(response => {
                this.version.publicada = true
            }).catch(error => {

            }).finally(() => {
                btn_loading("btn_publicar_form", 'Publicar', 'hide')
            })
        },
        updateNamePage: function (new_name) {
            this.pages.find(x => x.idCF_PaginaContent === new_name.idCF_PaginaContent).nombrePage = new_name.nombrePage
        },
        onDetailsVersion: async function () {
            this.version = null
            await axios.get(`../v2/api/Formacion/DetailsVersion?IdCF_Formacion=${this.$route.params.idCF_Formacion}&IdCF_Version=${this.$route.params.idCF_Version}`, null, null).then(response => {
                this.version = response.data
            }).catch(error => {

            }).finally(() => {

            })
        },
        onListContenidos: async function () {
            this.pages = []
            await axios.get(`../v2/api/Formacion/ListContenidos?IdCF_Formacion=${this.$route.params.idCF_Formacion}&IdCF_Version=${this.$route.params.idCF_Version}`, null, null).then(response => {
                this.pages = response.data
            }).catch(error => {

            }).finally(() => {

            })
        },
        onAddContenido: async function () {
            let contenido = {
                pageContent: null,
                idCF_Version: parseInt(this.$route.params.idCF_Version),
                nombrePage: 'new content',
                noPage: 0
            }
            
            btn_loading("new_page_content", 'Registrando')
            await axios.post(`../v2/api/Formacion/AddContenido/${this.$route.params.idCF_Formacion}/${this.$route.params.idCF_Version}`, contenido, null).then(response => {
                this.pages.push(response.data)
            }).catch(error => {

            }).finally(() => {
                btn_loading("new_page_content", 'Nuevo', 'hide')
                
            })
        }
    }
}

Vue.component('evaluacion-actions', {
    props: ['idCF_Evaluacion'],
    template: `
<div>
    <div class="contact-content-sidebar" v-if="evaluacion !== null">
        
        <h5 id="contactName" class="tx-18 tx-xl-20 mg-b-5">{{ evaluacion.folio }}</h5>
        <p class="tx-13 tx-lg-12 tx-xl-13 tx-color-03 mg-b-20">{{ evaluacion.nombre }}</p>

        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Descripción</label>
        <p class="tx-13 mg-b-0">
            {{ evaluacion.descripcion }}
        </p>

        <hr class="mg-y-20">

        <nav class="nav flex-column contact-content-nav mg-b-25 mt-3 mb-3">
            <a class="nav-link" data-toggle="tooltip" title="Evaluacion activa" v-if="evaluacion.activa"><i class="fas fa-arrow-up"></i> Evaluacion activa</a>
            <a class="nav-link" data-toggle="tooltip" title="Evaluacion inactiva" v-if="!evaluacion.activa"><i class="fas fa-arrow-down"></i> Evaluacion inactiva</a>
        </nav>

        <button class="btn btn-sm btn-white btn-block" v-on:click="beforeEvaEdit">Editar <i class="fas fa-pen"></i></button>

    </div><!-- contact-content-sidebar -->
    <div class="modal fade effect-scale" id="moda_edit_evaluacion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document" v-if="evaluacion !== null">
            <div class="modal-content">
                <div class="modal-body pd-20 pd-sm-30">
                    <button type="button" class="close pos-absolute t-15 r-20" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                    <h5 class="tx-18 tx-sm-20 mg-b-20">Editar evaluación</h5>
                    <p class="tx-13 tx-color-03 mg-b-30">
                        Por favor introduce la siguiente información,
                    </p>

                    <div class="d-sm-flex">
                        <div class="flex-fill">
                            <api-result class="mt-2 mb-2" v-if="proccess.api_form_edit !== null" :response_api="proccess.api_form_edit"></api-result>
                            <div class="form-group mg-b-10">
                                <label>Nombre</label>
                                <textarea class="form-control" rows="4" placeholder="Agrega tu descripción" v-model="evaluacion_updModel.nombre"></textarea>
                            </div><!-- form-group -->
                            <div class="form-group mg-b-10">
                                <label>Descripción</label>
                                <textarea class="form-control" rows="15" placeholder="Agrega tu descripción" v-model="evaluacion_updModel.descripcion"></textarea>
                            </div><!-- form-group -->
                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" :id="'check_activa' + idCF_Evaluacion" v-model="evaluacion_updModel.activa">
                                <label class="custom-control-label" :for="'check_activa' + idCF_Evaluacion">Activar evaluación</label>
                            </div>
                        </div><!-- col -->

                    </div>
                </div>
                <div class="modal-footer">
                    <div class="wd-100p d-flex flex-column flex-sm-row justify-content-end">
                        <button type="button" class="btn btn-secondary mg-sm-l-5" data-dismiss="modal" v-on:click="onCancelUpdate">Cancelar</button>
                        <button type="button" class="btn btn-primary mg-b-5 mg-sm-b-0 ml-2" :disabled="evaluacion_updModel.nombre.trim() === '' || evaluacion_updModel.descripcion.trim() === ''" v-on:click="onEvaEdit">Guardar</button>
                    </div>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>
    `,
    data: function () {
        return {
            evaluacion: null,
            evaluacion_updModel: null,
            proccess: {
                api_form_edit: null
            }
        }
    },
    async mounted() {
        await this.onEvaDetails();
        //new PerfectScrollbar('.contact-content-sidebar', {
        //    suppressScrollX: true
        //});
    },
    watch: {
        idCF_Evaluacion: function (newVal, oldVal) {
            this.onEvaDetails();
        }
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onCancelUpdate: function () {
            this.evaluacion_updModel = {
                idCF_Evaluacion: this.evaluacion.idCF_Evaluacion,
                nombre: this.evaluacion.nombre,
                descripcion: this.evaluacion.descripcion,
                activa: this.evaluacion.activa,
            }
        },
        onEvaEdit: async function () {
            this.proccess.api_form_edit = {
                loadding: true
            }

            await axios.put(`../v2/api/FormacionEva/EvaEdit/${this.idCF_Evaluacion}`, this.evaluacion_updModel, null).then(response => {
                this.proccess.api_form_edit = null
                $("#moda_edit_evaluacion").modal("hide")
                this.evaluacion.idCF_Evaluacion = this.evaluacion_updModel.idCF_Evaluacion
                this.evaluacion.nombre = this.evaluacion_updModel.nombre
                this.evaluacion.descripcion = this.evaluacion_updModel.descripcion
                this.evaluacion.activa = this.evaluacion_updModel.activa
            }).catch(error => {
                this.proccess.api_form_edit = {
                    loadding: false,
                    response_error: error
                }
            }).finally(() => {
                formacion_updModel = null;
            })
        },
        beforeEvaEdit: function () {
            $("#moda_edit_evaluacion").modal({
                backdrop: false, //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onEvaDetails: async function () {
            this.evaluacion = null
            await axios.get(`../v2/api/FormacionEva/EvaDetails/${this.idCF_Evaluacion}`, null, null).then(response => {
                this.evaluacion = response.data
                this.evaluacion_updModel = {
                    idCF_Evaluacion: response.data.idCF_Evaluacion,
                    nombre: response.data.nombre,
                    descripcion: response.data.descripcion,
                    activa: response.data.activa,
                }
            }).catch(error => {

            }).finally(() => {

            })
        }
    }
})
//evaluacion - templates
Vue.component('evaluacion-templates', {
    props: [],
    template: `
<div>
    <div class="placeholder-paragraph ml-2 mt-2" v-if="loadding === true">
        <div class="line"></div>
        <div class="line"></div>
    </div>
    <div class="pd-y-20 pd-x-10 contact-list" v-if="loadding === false && evaluaciones.length > 0">
        <div v-for="(eva, eva_index) in evaluaciones" :class="'media ' + (parseInt($route.params.idCF_Evaluacion) === eva.idCF_Evaluacion ? 'active' : '' )"  :key="eva.idCF_Evaluacion">
            <div class="media-body mg-l-10">
                <h6 class="tx-13 mg-b-3">{{ eva.folio }}</h6>
                <span class="tx-12">{{ eva.nombre | reducir }}</span>
            </div><!-- media-body -->
            <nav>
                <router-link :to="{ name: 'admin-evaluacion-design', params: { idCF_Evaluacion : eva.idCF_Evaluacion }}" title="ver esta evaluación">
                    <i class="fas fa-swatchbook"></i>
                </router-link>
            </nav>
        </div><!-- media -->
    </div><!-- contact-list -->
    <div v-if="loadding === false && evaluaciones.length <= 0" class="content content-fixed content-auth-alt mt-5">
        <div class="container ht-100p tx-center mt-5">
            <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                <h4 class="tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5">Sin diseños</h4>
            </div>
        </div><!-- container -->
    </div><!-- content -->
</div>

    `,
    data: function () {
        return {
            info: '',
            evaluaciones: [],
            loadding: false
        }
    },
    async mounted() {
        this.onEvaList();
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {

    },
    computed: {
        addNew: function (elemt) {
            console.log(elemt)
        }
    },
    methods: {
        onEvaList: async function () {
            this.loadding = true
            this.evaluaciones = []
            await axios.get(`../v2/api/FormacionEva/EvaList`, null, null).then(response => {
                this.evaluaciones = response.data
            }).catch(error => {
                GlobalValidAxios(error);
            }).finally(() => {
                this.loadding = false
            })
        },
    },
    filters: {
        reducir: function (cadena) {
            return cadena.length > 100 ? cadena.substring(0, 100) + "..." : cadena;
        }
    }
})
//evaluacion - btn - add
Vue.component('evaluacion-btn-add', {
    props: [],
    template: `
<div>
    <a class="btn btn-xs btn-icon btn-primary tx-white" v-on:click="openModalAdd()">
        <span data-toggle="tooltip" title="Agregar nueva evaluación"><i class="icon ion-md-add tx-white"></i></span>
    </a><!-- contact-add -->
    <div class="modal fade effect-scale" id="modal_nw_evaluacion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body pd-20 pd-sm-30">
                    <button type="button" class="close pos-absolute t-15 r-20" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                    <h5 class="tx-18 tx-sm-20 mg-b-20">Crear nueva evaluación</h5>
                    <p class="tx-13 tx-color-03 mg-b-30">
                        Por favor introduce la siguiente información para crear una nueva evaluacion,
                    </p>

                    <div class="d-sm-flex">
                        <div class="flex-fill">
                            <api-result class="mt-2 mb-2" v-if="proccess.api_proc_add !== null" :response_api="proccess.api_proc_add"></api-result>
                            <div class="form-group mg-b-10">
                                <label>Nombre</label>
                                <input type="text" class="form-control" placeholder="Nombre de la evaluación" v-model="evaluacion.nombre">
                            </div><!-- form-group -->
                            <div class="form-group mg-b-10">
                                <label>Descripción</label>
                                <textarea class="form-control" rows="2" placeholder="Agrega tu descripción" v-model="evaluacion.descripcion"></textarea>
                            </div><!-- form-group -->
                        </div><!-- col -->
                        
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="wd-100p d-flex flex-column flex-sm-row justify-content-end">
                        <button type="button" class="btn btn-secondary mg-sm-l-5" data-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary mg-b-5 mg-sm-b-0" :disabled="evaluacion.nombre.trim() === '' || evaluacion.descripcion.trim() === ''" v-on:click="onAddFormacion()">Guardar</button>
                    </div>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>
    `,
    data: function () {
        return {
            info: '',
            evaluacion: {
                nombre: '',
                descripcion: '',
                activa: false
            },
            proccess: {
                api_proc_add: null
            }
        }
    },
    async mounted() {
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        openModalAdd: function () {
            this.proccess.api_proc_add = null;
            this.evaluacion.nombre = ''
            this.evaluacion.descripcion = ''
            $("#modal_nw_evaluacion").modal({
                backdrop: false, //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
            //$('.modal-backdrop').remove();
        },
        onAddFormacion: async function () {
            this.proccess.api_proc_add = {
                loadding: true
            }
            await axios.post(`../v2/api/FormacionEva/EvaCreate`, this.evaluacion, null).then(response => {
                this.proccess.api_proc_add = {
                    loadding: false,
                }
                this.$emit('addNew', response.data)
                $("#modal_nw_evaluacion").modal("hide")
            }).catch(error => {
                this.proccess.api_proc_add = {
                    loadding: false,
                    response_error: error
                }
            }).finally(() => {

            })
        },
    }
})
//version - btn - add
Vue.component('version-btn-add-evaluacion', {
    props: ['idCF_Evaluacion'],
    template: `
<div>
    <a class="text-secondary mg-l-auto" v-on:click="openModalAdd()" >
        <span data-toggle="tooltip" title="Nueva version"><i class="fas fa-sitemap"></i></span>
    </a><!-- contact-add -->
    <div class="modal fade effect-scale" id="moda-eva-version-add" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body pd-20 pd-sm-30">
                    <button type="button" class="close pos-absolute t-15 r-20" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                    <h5 class="tx-18 tx-sm-20 mg-b-20">Crear nueva versión</h5>
                    <p class="tx-13 tx-color-03 mg-b-30">
                        Por favor introduce la siguiente información para crear una nueva versión,
                    </p>

                    <div class="d-sm-flex">
                        <div class="flex-fill">
                            <api-result class="mt-2 mb-2" v-if="proccess.api_proc_add !== null" :response_api="proccess.api_proc_add"></api-result>
                            <div class="form-group mg-b-10">
                                <label>Comentarios</label>
                                <textarea class="form-control" rows="2" placeholder="comentarios" v-model="version.comentarios"></textarea>
                            </div><!-- form-group -->
                            <div class="form-group mg-b-10">
                                <label>Instrucciones</label>
                                <textarea class="form-control" rows="2" placeholder="instrucciones" v-model="version.instrucciones"></textarea>
                            </div><!-- form-group -->
                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" id="customCheck1" v-model="version.aleatory">
                                <label class="custom-control-label" for="customCheck1">Mostrar preguntas aleatoriamente</label>
                            </div>
                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" id="customCheck12" v-model="version.bySecciones">
                                <label class="custom-control-label" for="customCheck12">Evaluacion organizada por secciones</label>
                            </div>
                        </div><!-- col -->
                        
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="wd-100p d-flex flex-column flex-sm-row justify-content-end">
                        <button type="button" class="btn btn-secondary mg-sm-l-5" data-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary mg-b-5 mg-sm-b-0  ml-2" :disabled="version.comentarios.trim() === ''" v-on:click="onEvaVersionCreate()" id="add_new_version_eva">Guardar</button>
                    </div>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>
    `,
    data: function () {
        return {
            info: '',
            version: {
                comentarios: '',
                instrucciones: '',
                idCF_Evaluacion: parseInt(this.idCF_Evaluacion),
                activa: false,
                aleatory: false,
                bySecciones: false,
                noVersion: 1,
                minCalificacion: 10
            },
            proccess: {
                api_proc_add: null
            }
        }
    },
    async mounted() {
    },
    watch: {

    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        openModalAdd: function () {
            this.proccess.api_proc_add = null;
            this.version.comentarios = ''
            $("#moda-eva-version-add").modal({
                backdrop: false, //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
            //$('.modal-backdrop').remove();
        },
        onEvaVersionCreate: async function () {
            this.proccess.api_proc_add = {
                loadding: true
            }
            this.version.idCF_Evaluacion = parseInt(this.idCF_Evaluacion)
            this.version.idCF_Evaluacion = parseInt(this.idCF_Evaluacion)
            btn_loading("add_new_version_eva", 'Guardando')
            await axios.post(`../v2/api/FormacionEva/EvaVersionCreate/${this.idCF_Evaluacion}`, this.version, null).then(response => {
                btn_loading("add_new_version_eva", 'Guardar', 'hide')
                this.proccess.api_proc_add = {
                    loadding: false,
                }
                this.$emit('addNew', response.data)
                $("#moda-eva-version-add").modal("hide")
            }).catch(error => {
                btn_loading("add_new_version_eva", 'Guardar', 'hide')
                this.proccess.api_proc_add = {
                    loadding: false,
                    response_error: error
                }
            }).finally(() => {

            })
        },
    }
})
//eva - version - seccion - preguntas
Vue.component('eva-version-seccion-preguntas', {
    props: ['idCF_EvaluacionVersion','idCF_EvaluacionSeccion', 'publicada'],
    template: `
<div>
    <eva-pregunta v-if="preguntas.length > 0"
        :idCF_EvaluacionVersion="idCF_EvaluacionVersion"
        :idCF_EvaluacionSeccion="idCF_EvaluacionSeccion"
        v-for="(pregunta, pregunta_index) in preguntas"
        :key="'pregunta_' + pregunta.idCF_EvaluacionPreg"
        :idCF_EvaluacionPreg="pregunta.idCF_EvaluacionPreg"
        :publicada="publicada"
        v-on:onEvaPregDeleteSeccion="preguntas.splice(pregunta_index, 1)"
    ></eva-pregunta>
    <a class="btn btn-xs btn-block btn-primary tx-white mt-4" v-on:click="onEvaPregCreateSeccion()" v-if="preguntas.length > 0 && publicada == false" style="color: white;">
        Agregar pregunta<i class="icon ion-md-add tx-white"></i>
    </a><!-- contact-add -->
    <div class="content content-fixed content-auth-alt mt-5"  v-if="preguntas.length <= 0">
        <div class="container ht-100p tx-center mt-5">
            <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                <h4 class="tx-color-01 tx-18 tx-sm-24 tx-lg-30 mg-xl-b-5">Sin preguntas</h4>
                <div class="wd-70p wd-sm-250 wd-lg-400 mg-b-15"><img src="https://ouch-cdn2.icons8.com/l2mWE4hjgAocEqEARVpS-27gLwV2SdIyZtzfUrl3asw/rs:fit:912:912/czM6Ly9pY29uczgu/b3VjaC1wcm9kLmFz/c2V0cy9zdmcvMjMw/L2QwNGUzMGQyLWY2/OTMtNDE0OS05OTI2/LWY5N2UxNWQ4OTUw/My5zdmc.png" class="img-fluid" alt=""></div>
                <div class="mg-b-40">
                    <button v-if="publicada == false" class="btn btn-sm btn-primary" data-toggle="tooltip" title="Agregar nueva seccion" :id="'new_preggunta' + idCF_EvaluacionVersion +''+ idCF_EvaluacionSeccion"  v-on:click="onEvaPregCreateSeccion">Agregar primer pregunta</button>
                </div>
            </div>
        </div><!-- container -->
    </div><!-- content -->
</div>
    `,
    data: function () {
        return {
            preguntas: []
        }
    },
    async mounted() {
        this.onEvaPregListSeccion()
    },
    watch: {
        idCF_EvaluacionVersion: function (newVal, oldVal) {
            this.onEvaPregListSeccion();
        },
        idCF_EvaluacionSeccion: function (newVal, oldVal) {
            this.onEvaPregListSeccion();
        }
    },
    methods: {
        onEvaPregCreateSeccion: async function () {
            let pregunta = {
                idCF_EvaluacionVersion: parseInt(this.idCF_EvaluacionVersion),
                idCF_EvaluacionSeccion: parseInt(this.idCF_EvaluacionSeccion),
                pregunta: 'Nueva pregunta',
                Contenido: null,
                Tipo: '',
                Orden: this.preguntas.length + 1
            }
            await axios.post(`../v2/api/FormacionEva/EvaPregCreateSeccion/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionSeccion}`, pregunta, null).then(response => {
                this.preguntas.push(response.data)
            }).catch(error => {

            }).finally(() => {
            })
        },
        onEvaPregListSeccion: async function () {
            this.preguntas = []
            await axios.get(`../v2/api/FormacionEva/EvaPregListSeccion/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionSeccion}`, null, null).then(response => {
                this.preguntas = response.data
            }).catch(error => {

            }).finally(() => {
            })
        }
    }
});
//eva - version - preguntas
Vue.component('eva-version-preguntas', {
    props: ['idCF_EvaluacionVersion', 'publicada'],
    template: `
<div>
    <eva-pregunta v-if="preguntas.length > 0"
        :idCF_EvaluacionVersion="idCF_EvaluacionVersion"
        :idCF_EvaluacionSeccion="null"
        v-for="(pregunta, pregunta_index) in preguntas"
        :key="'pregunta_' + pregunta.idCF_EvaluacionPreg"
        :idCF_EvaluacionPreg="pregunta.idCF_EvaluacionPreg"
        :publicada="publicada"
        v-on:onEvaPregDeleteSeccion="preguntas.splice(pregunta_index, 1)"
    ></eva-pregunta>
    <a class="btn btn-xs btn-block btn-primary tx-white mt-4" v-on:click="onEvaPregCreate()" ref="btn_add_pregunta" v-if="preguntas.length > 0 && publicada == false" style="color: white;">
        Agregar pregunta
    </a><!-- contact-add -->
    <div class="content content-fixed content-auth-alt mt-5"  v-if="preguntas.length <= 0">
        <div class="container ht-100p tx-center mt-5">
            <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                <h4 class="tx-color-01 tx-18 tx-sm-24 tx-lg-30 mg-xl-b-5">Sin preguntas</h4>
                <div class="wd-70p wd-sm-250 wd-lg-400 mg-b-15"><img src="https://ouch-cdn2.icons8.com/l2mWE4hjgAocEqEARVpS-27gLwV2SdIyZtzfUrl3asw/rs:fit:912:912/czM6Ly9pY29uczgu/b3VjaC1wcm9kLmFz/c2V0cy9zdmcvMjMw/L2QwNGUzMGQyLWY2/OTMtNDE0OS05OTI2/LWY5N2UxNWQ4OTUw/My5zdmc.png" class="img-fluid" alt=""></div>
                <div class="mg-b-40" v-if="publicada == false">
                    <button class="btn btn-sm btn-primary" data-toggle="tooltip" title="Agregar nueva seccion" ref="btn_add_pregunta"  v-on:click="onEvaPregCreate">Agregar primer pregunta</button>
                </div>
            </div>
        </div><!-- container -->
    </div><!-- content -->
</div>
`,
    data: function (){
        return {
            preguntas: []
        }
    },
    watch: {
        idCF_EvaluacionVersion: async function (newVal, oldVal) {
            await this.onEvaPregList();
        },
    },
    async mounted() {
        await this.onEvaPregList();
    },
    methods: {
        onEvaPregCreate: async function () {
            let pregunta = {
                idCF_EvaluacionVersion: parseInt(this.idCF_EvaluacionVersion),
                idCF_EvaluacionSeccion: 0,
                pregunta: 'Nueva pregunta',
                Contenido: null,
                Tipo: '',
                Orden: this.preguntas.length + 1
            }
            await axios.post(`../v2/api/FormacionEva/EvaPregCreate/${this.idCF_EvaluacionVersion}/`, pregunta, null).then(response => {
                this.preguntas.push(response.data)
            }).catch(error => {

            }).finally(() => {
            })
        },
        onEvaPregList: async function () {
            this.preguntas = []
            await axios.get(`../v2/api/FormacionEva/EvaPregList/${this.idCF_EvaluacionVersion}`, null, null).then(response => {
                this.preguntas = response.data
            }).catch(error => {

            }).finally(() => {
            })
        }
    }
});
//eva - pregunta
Vue.component('eva-pregunta', {
    props: ['idCF_EvaluacionVersion', 'idCF_EvaluacionSeccion', 'idCF_EvaluacionPreg', 'publicada'],
    template: `
<div>

    <div v-if="pregunta !== null" class="mt-3 bd-l bd-2 bd-primary p-2 bg-white pb-3 pt-3">
        <h6 class="mg-b-0 tx-primary"> {{ pregunta.pregunta }}</h6>
        <span v-if="pregunta.tipo !== ''" class="tx-11">{{ listTipo.find(x => x.value === pregunta.tipo).text }}</span>
        <span v-else class="tx-11">sin definición de tipo de pregunta</span>
        <br>
        <span class="tx-11">Ultima actualización: {{ pregunta.updatedAt  | datetime_calendar }}</span>
        <hr>
        <div v-html="contentHTML"></div>
        <div class="bd bg-gray-50" v-if="respuestas.length > 0">
            <h6 class="ml-2 mt-3">Respuestas:</h6>
            <ul>
                <li v-for="(respuesta, respuesta_index) in respuestas" :key="'resp_' + respuesta_index">{{ respuesta.respuesta }}</li>
            </ul>
        </div>
        <nav class="nav nav-row mg-t-15" v-if="publicada === false">
            <a v-on:click="openModalAdd" class="nav-link linkds" style="color: #0168fa !important;text-decoration: none !important;background-color: transparent !important;">Editar</a>
            <a v-on:click="onEvaPregDeleteSeccion" class="nav-link linkds" style="color: #0168fa !important;text-decoration: none !important;background-color: transparent !important;">Eliminar</a>
        </nav>
        <div class="modal fade effect-scale" :id="'modal_edit_pregunta' + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
                <div class="modal-content" style="min-height: 600px;">
                    <div class="modal-body pd-20 pd-sm-30">
                        <button type="button" class="close pos-absolute t-15 r-20" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>

                        <h5 class="tx-18 tx-sm-20 mg-b-20">Editar pregunta</h5>
                        <p class="tx-13 tx-color-03 mg-b-30">
                            Por favor introduce la siguiente información,
                        </p>
                        <ul class="nav nav-tabs" :id="'modal_tabs' + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active"
                                    :id="'tab_uno' + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" data-toggle="tab"
                                    :href="'#tab-content-uno'  + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" role="tab" aria-controls="tab-content-uno" aria-selected="true">Pregunta</a>
                            </li>
                            <li class="nav-item" v-if="pregunta2.tipo === 'OPTIO' || pregunta2.tipo === 'MLOPT'">
                                <a class="nav-link"
                                    :id="'tab_dos' + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" data-toggle="tab"
                                    :href="'#tab-content-dos'  + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" role="tab" aria-controls="tab-content-dos" aria-selected="true">Respuestas</a>
                            </li>
                        </ul>
                        <div class="tab-content bd bd-gray-300 bd-t-0 pd-20" id="myTabContent">
                            <div class="tab-pane fade show active" :id="'tab-content-uno'  + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" role="tabpanel" aria-labelledby="home-tab">
                                <div class="d-sm-flex">
                                    <div class="flex-fill">
                                        <api-result class="mt-2 mb-2" v-if="proccess.api_proc_add !== null" :response_api="proccess.api_proc_add"></api-result>
                                        <div class="form-group mg-b-10">
                                            <label>Pregunta</label>
                                            <input type="text" class="form-control" placeholder="Nombre de la formación" v-model="pregunta2.pregunta">
                                        </div><!-- form-group -->
                                        <div class="form-group mg-b-10">
                                            <label>Pregunta</label>
                                            <select v-model="pregunta2.tipo" class="form-control form-control-sm">
                                                <option v-for="option in listTipo" v-bind:value="option.value">
                                                    {{ option.text }}
                                                </option>
                                            </select>
                                        </div><!-- form-group -->
                                    </div><!-- col -->
                                </div>
                                <div :id="'editor_html_pregunta' + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" class="tx-13 tx-lg-14 ht-100 mt-2" style="min-height: 200px;">
                                </div>
                                <div class="d-flex align-items-center justify-content-between mg-t-10" v-if="publicada === false">
                                    <div class="btn-group">
                                        <button class="btn btn-white btn-xs"
                                            :id="'btn_save_pregunta' + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg"
                                            :disabled="pregunta2.pregunta.trim() === '' || pregunta2.tipo.trim() === ''"
                                            v-on:click="onEvaPregEdit">Guardar</button>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" v-if="pregunta2.tipo === 'OPTIO' || pregunta2.tipo === 'MLOPT'" :id="'tab-content-dos'  + idCF_EvaluacionVersion + '' + pregunta.idCF_EvaluacionPreg" role="tabpanel" aria-labelledby="profile-tab">
                                <table class="table table-sm table-hover">
                                    <tr>
                                        <th>Pregunta</th>
                                        <th style="width: 50px;" v-if="publicada === false"></th>
                                    </tr>
                                     <tr v-for="(respuesta, respuesta_index) in respuestas" >
                                        <td>
                                            <textarea class="form-control" rows="1" placeholder="Respuesta" v-model="respuesta.respuesta" v-on:change="onEvaPregRespEdit(respuesta.idCF_EvaluacionPregRes, respuesta_index)"></textarea>
                                        </td>
                                        <td v-if="publicada === false">
                                            <button class="btn tx-danger tx-13" title="eliminar esta respuesta" v-on:click="onEvaPregRespDelete(respuesta.idCF_EvaluacionPregRes, respuesta_index)"><i class="typcn typcn-trash"></i></button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <textarea class="form-control" rows="1" placeholder="introduce aqui " v-model="new_respuesta" ref="text_new_resp"></textarea>
                                        </th>
                                        <th v-if="publicada === false">
                                            <button  class="btn btn-sm btn-primary" :disabled="new_respuesta.trim() === ''" v-on:click="onEvaPregRespCreate">Agregar</button>
                                        </th>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div><!-- modal-content -->
            </div><!-- modal-dialog -->
        </div><!-- modal -->
    </div>
</div>
    `,
    data: function () {
        return {
            respuestas: [],
            pregunta2: null,
            pregunta: null,
            contentHTML: '',
            new_respuesta: '',
            editorHTML: null,
            proccess:{
                api_proc_add: null
            },
            listTipo: [
                { value: 'OPEN', text: 'Entrada de texto por el usuario' },
                { value: 'OPTIO', text: 'Solo una opción valida' },
                { value: 'MLOPT', text: 'Mas de una opción valida' }
            ],
        }
    },
    watch: {
        idCF_EvaluacionVersion: async function (newVal, oldVal) {
            //await this.onEvaPregDetails();
            //await this.onEvaPregRespList();
        },
        idCF_EvaluacionSeccion: async function (newVal, oldVal) {
            //await this.onEvaPregDetails();
            //await this.onEvaPregRespList();
        },
        pregunta: async function (newVal, oldVal) {
            //await this.onEvaPregDetails();
            //await this.onEvaPregRespList();
        }
    },
    async mounted() {   
        await this.onEvaPregDetails();
        await this.onEvaPregRespList();
        console.log(this.idCF_EvaluacionSeccion)
        this.onDetailsVersionPageHTML();
    },
    methods: {
        testEditor: function () {
            console.log(this.editorHTML)
        },
        onEvaPregDeleteSeccion: async function () {
            let endPoint = ''
            if (this.idCF_EvaluacionSeccion === null || this.idCF_EvaluacionSeccion === undefined) {
                endPoint = `../v2/api/FormacionEva/EvaPregDelete/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionPreg}`
            } else {
                endPoint = `../v2/api/FormacionEva/EvaPregDeleteSeccion/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionSeccion}/${this.idCF_EvaluacionPreg}`
            }
            await axios.delete(endPoint, null, null).then(response => {
                this.$emit("onEvaPregDeleteSeccion")
            }).catch(error => {

            }).finally(() => {

            })
        },
        onEvaPregRespEdit: async function (idCF_EvaluacionPregRes, index) {
            let contenido = {

                IdCF_EvaluacionPreg: parseInt(this.idCF_EvaluacionPreg),
                idCF_EvaluacionPregRes: parseInt(this.respuestas[index].idCF_EvaluacionPregRes),
                Respuesta: this.respuestas[index].respuesta,
                ImgOpcion: null
            }
            
            await axios.put(`../v2/api/FormacionEva/EvaPregRespEdit/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionPreg}/${idCF_EvaluacionPregRes}`, contenido, null).then(response => {
                ShowMessageErrorShort('Datos guardados', 'success')
            }).catch(error => {

            }).finally(() => {
                
            })
        },
        onEvaPregRespDelete: async function (idCF_EvaluacionPregRes, index) {
            await axios.delete(`../v2/api/FormacionEva/EvaPregRespDelete/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionPreg}/${idCF_EvaluacionPregRes}`, null, null).then(response => {
                this.respuestas.splice(index, 1)
            }).catch(error => {

            }).finally(() => {

            })
        },
        onEvaPregRespCreate: async function () {
            if (this.new_respuesta.trim().length > 0) {
                let contenido = {
                    IdCF_EvaluacionPreg: parseInt(this.idCF_EvaluacionPreg),
                    Respuesta: this.new_respuesta,
                    ImgOpcion: null
                }
                await axios.post(`../v2/api/FormacionEva/EvaPregRespCreate/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionPreg}`, contenido, null).then(response => {
                    this.respuestas.push(response.data)
                    this.new_respuesta = ''
                    this.$refs.text_new_resp.focus();
                }).catch(error => {

                }).finally(() => {

                })
            }
        },
        onStartEditor: function () {
            if (this.editorHTML === null) {
                // reply form
                let toolbarOptions = [
                    ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
                    ['blockquote', 'code-block'],
                    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                    [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
                    [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
                    [{ 'direction': 'rtl' }],                         // text direction

                    [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

                    [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
                    [{ 'font': [] }],
                    [{ 'align': [] }],

                    ['clean']                                         // remove formatting button
                ];
                this.editorHTML = new Quill("#editor_html_pregunta" + this.idCF_EvaluacionVersion + '' + this.idCF_EvaluacionPreg, {
                    modules: {
                        //toolbar: "#editor_tool_html_pregunta" + this.idCF_EvaluacionVersion + '' + this.idCF_EvaluacionPreg
                        toolbar: toolbarOptions
                    },
                    placeholder: 'escribe aqui tu descripcion ',
                    theme: 'snow'
                });
            }
        },
        onDetailsVersionPageHTML: async function () {
            if (this.pregunta.descipcionPath !== '' && this.pregunta.descipcionPath !== null) {
                await axios.get(`../${this.pregunta.descipcionPath}`, null, null).then(response => {
                    this.contentHTML = response.data
                    //this.editorHTML.root.innerHTML = response.data
                }).catch(error => {

                }).finally(() => {

                })
            }
        },
        onEvaPregDetails: async function () {
            await axios.get(`../v2/api/FormacionEva/EvaPregDetails/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionPreg}`, null, null).then(response => {
                this.pregunta = response.data
                this.pregunta2 = response.data
            }).catch(error => {

            }).finally(() => {
                
            })
        },
        onEvaPregEdit: async function () {
            let id_btn_add = 'btn_save_pregunta' + this.idCF_EvaluacionVersion + '' + this.pregunta.idCF_EvaluacionPreg
            btn_loading(id_btn_add, 'Guardando')
            //console.log(this.editorHTML.root.innerHTML)
            
            let contenido = new FormData()
            contenido.append("IdCF_EvaluacionPreg", parseInt(this.pregunta.idCF_EvaluacionPreg));
            contenido.append("IdCF_EvaluacionVersion", parseInt(this.idCF_EvaluacionVersion));
            
            contenido.append("Pregunta", this.pregunta2.pregunta);
            contenido.append("Tipo", this.pregunta2.tipo);
            contenido.append("Orden", this.pregunta2.orden);

            if (this.editorHTML.root.innerHTML !== '<p><br></p>') {
                let file = new File([this.editorHTML.root.innerHTML], "foo.html", {
                    type: "text/html",
                })
                contenido.append("Contenido", file);
            } else {
                contenido.append("Contenido", null);
            }

            const config = {
                headers: {
                    'content-type': 'multipart/form-data;'
                }
            }
            let endPoint = ''
            if (this.pregunta.idCF_EvaluacionSeccion !== null) {
                contenido.append("IdCF_EvaluacionSeccion", parseInt(this.idCF_EvaluacionSeccion));
                endPoint = `../v2/api/FormacionEva/EvaPregEditSeccion/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionSeccion}/${this.idCF_EvaluacionPreg}`
                
            } else {
                contenido.append("IdCF_EvaluacionSeccion", 0);
                endPoint = `../v2/api/FormacionEva/EvaPregEdit/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionPreg}`
            }
            await axios.put(endPoint, contenido, config).then(response => {
                this.onEvaPregDetails();
                if (this.editorHTML.root.innerHTML !== '<p><br></p>') {
                    this.contentHTML = this.editorHTML.root.innerHTML
                } else {
                    this.contentHTML = ''
                }
                
            }).catch(error => {

            }).finally(() => {
                btn_loading(id_btn_add, 'Guardar', 'hide')
            })
        },
        openModalAdd: function () {
            //  = response.data
            this.onStartEditor();
            this.editorHTML.root.innerHTML = this.contentHTML
            $("#modal_edit_pregunta" + this.idCF_EvaluacionVersion + '' + this.pregunta.idCF_EvaluacionPreg).modal({
                backdrop: false, //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
            //$('.modal-backdrop').remove();
        },
        onEvaPregRespList: async function () {
            this.respuestas = []
            await axios.get(`../v2/api/FormacionEva/EvaPregRespList/${this.idCF_EvaluacionVersion}/${this.idCF_EvaluacionPreg}`, null, null).then(response => {
                this.respuestas = response.data
            }).catch(error => {

            }).finally(() => {
            })
        }
    }
})
//eva - version - secciones
Vue.component('eva-version-secciones', {
    props: ['idCF_Evaluacion', 'idCF_EvaluacionVersion','publicada'],
    template: `
<div>
    <h1 v-if="secciones.length > 0">Secciones</h1>
    <ul class="nav nav-tabs" id="myTab" role="tablist"  v-if="secciones.length > 0">
        <li class="nav-item"
            v-for="(seccion, seccion_index) in secciones">
            <a
                v-if="publicada === false"
                :class="'nav-link '+ (selected === seccion_index ? 'active' : '')"
                v-on:dblclick="beforeEdit(seccion_index)"
                :title="'doble click para editar: '+ seccion.nombre"
                v-on:click="selected = seccion_index"  data-toggle="tab"
                :href="'#tab_'+seccion.idCF_EvaluacionSeccion" role="tab" aria-controls="home" aria-selected="true">
                    {{seccion.nombre}}
                    <button   class="btn btn-x" v-on:click="onEvaSeccionDelete(seccion.idCF_EvaluacionSeccion, seccion_index )" title="Eliminar esta seccion">x</button>
            </a>
            <a
                v-if="publicada === true"
                :class="'nav-link '+ (selected === seccion_index ? 'active' : '')"
                v-on:click="selected = seccion_index"  data-toggle="tab"
                :href="'#tab_'+seccion.idCF_EvaluacionSeccion" role="tab" aria-controls="home" aria-selected="true">
                {{seccion.nombre}}
            </a>
            
        </li>
        <li class="nav-item" v-if="publicada === false">
            <button class="btn btn-sm btn-primary" data-toggle="tooltip" title="Agregar nueva seccion" id="new_seccion_content"  v-on:click="onEvaSeccionCreate">Nuevo</button>
        </li>
    </ul>
    <div class="tab-content bd bd-gray-300 bd-t-0 pd-20" id="myTabContent" style="height: 100%;background: white;" v-if="secciones.length > 0">
        <div
        v-for="(seccion, seccion_index) in secciones" 
        :class="'tab-pane fade '+ (selected === seccion_index ? ' show active' : '')"
        :id="'tab_'+seccion.idCF_EvaluacionSeccion" role="tabpanel" aria-labelledby="home-tab" style="height: 100%;">
            <eva-version-seccion-preguntas
                :idCF_EvaluacionVersion="idCF_EvaluacionVersion"
                :idCF_EvaluacionSeccion="seccion.idCF_EvaluacionSeccion"
                :publicada="publicada"
            ></eva-version-seccion-preguntas>
        </div>
    </div>
    <div class="content content-fixed content-auth-alt mt-5"  v-if="secciones.length <= 0">
        <div class="container ht-100p tx-center mt-5">
            <div class="ht-100p d-flex flex-column align-items-center justify-content-center">
                <h5 class="tx-color-01 tx-18 tx-sm-26 tx-lg-30 mg-xl-b-5">Sin secciones</h5>
                <div class="wd-70p wd-sm-250 wd-lg-500 mg-b-15"><img src="https://ouch-cdn2.icons8.com/l2mWE4hjgAocEqEARVpS-27gLwV2SdIyZtzfUrl3asw/rs:fit:912:912/czM6Ly9pY29uczgu/b3VjaC1wcm9kLmFz/c2V0cy9zdmcvMjMw/L2QwNGUzMGQyLWY2/OTMtNDE0OS05OTI2/LWY5N2UxNWQ4OTUw/My5zdmc.png" class="img-fluid" alt=""></div>
                <div class="mg-b-40">
                    <button class="btn btn-sm btn-primary" v-if="publicada === false" data-toggle="tooltip" title="Agregar nueva seccion" id="new_seccion_content"  v-on:click="onEvaSeccionCreate">Agregar primer seccion</button>
                </div>
            </div>
        </div><!-- container -->
    </div><!-- content -->
    <div class="modal fade effect-scale" id="model_edit_seccion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content"  v-if="seccionEdit !== null">
                <div class="modal-body pd-20 pd-sm-30">
                    <button type="button" class="close pos-absolute t-15 r-20" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                    <h5 class="tx-18 tx-sm-20 mg-b-20">Editar sección</h5>
                    <p class="tx-13 tx-color-03 mg-b-30">
                        Por favor introduce la siguiente información para continuar
                    </p>

                    <div class="d-sm-flex">
                        <div class="flex-fill">
                            <api-result class="mt-2 mb-2" v-if="proccess.api_proc_add !== null" :response_api="proccess.api_proc_add"></api-result>
                            <div class="form-group mg-b-10">
                                <label>Nombre</label>
                                <input type="text" class="form-control" placeholder="Nombre de la seccion" v-model="seccionEdit.nombre">
                            </div><!-- form-group -->
                        </div><!-- col -->

                    </div>
                </div>
                <div class="modal-footer">
                    <div class="wd-100p d-flex flex-column flex-sm-row justify-content-end">
                        <button type="button" class="btn btn-secondary mg-sm-l-5" data-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary mg-b-5 mg-sm-b-0 ml-2" :disabled="seccionEdit.nombre.trim() === ''" id="btn_save_section_changes" v-on:click="onEvaSeccionEdit()">Guardar</button>
                    </div>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>
    `,
    data: function () {
        return {
            info: '',
            secciones: [],
            selected: 0,
            proccess: {
                api_proc_add: null
            },
            seccionEdit: null
        }
    },
    async mounted() {
        this.onEvaSeccionList()
    },
    watch: {
        idCF_EvaluacionVersion: function (newVal, oldVal) {
            console.log(newVal)
            console.log(oldVal)
            this.onEvaSeccionList();
        },
    },
    renderTriggered({ key, target, type }) {

    },
    methods: {
        onEvaSeccionEdit: async function () {
            
            let contenido = {
                idCF_EvaluacionVersion: parseInt(this.seccionEdit.idCF_EvaluacionVersion),
                idCF_EvaluacionSeccion: parseInt(this.seccionEdit.idCF_EvaluacionSeccion),
                nombre: this.seccionEdit.nombre,
            }
            btn_loading("btn_save_section_changes", 'Registrando')
            await axios.put(`../v2/api/FormacionEva/EvaSeccionEdit/${this.idCF_EvaluacionVersion}/${this.seccionEdit.idCF_EvaluacionSeccion}`, contenido, null).then(async (response) => {
                btn_loading("btn_save_section_changes", 'Guardar', 'hide')
                this.secciones.find(x => x.idCF_EvaluacionSeccion === contenido.idCF_EvaluacionSeccion).nombre = this.seccionEdit.nombre


                $("#model_edit_seccion").modal('hide')
            }).catch(error => {
                btn_loading("btn_save_section_changes", 'Guardar', 'hide')
            }).finally(() => {
                
            })
        },
        beforeEdit: function (index) {
            this.seccionEdit = JSON.parse(JSON.stringify(this.secciones[index]));
            $("#model_edit_seccion").modal({
                backdrop: false, //remove ability to close modal with click
                keyboard: false, //remove option to close with keyboard
                show: true //Display loader!
            });
        },
        onEvaSeccionDelete: async function (idCF_EvaluacionSeccion, index) {
            await axios.delete(`../v2/api/FormacionEva/EvaSeccionDelete/${this.idCF_EvaluacionVersion}/${idCF_EvaluacionSeccion}`, null, null).then(response => {
                this.secciones.splice(index,1)
            }).catch(error => {

            }).finally(() => {
            })
        },
        onEvaSeccionCreate: async function () {
            let contenido = {
                idCF_EvaluacionVersion: parseInt(this.$route.params.idCF_EvaluacionVersion),
                nombre: 'new section',
            }
            btn_loading("new_seccion_content", 'Registrando')
            await axios.post(`../v2/api/FormacionEva/EvaSeccionCreate/${this.idCF_EvaluacionVersion}`, contenido, null).then(response => {
                this.secciones.push(response.data)
            }).catch(error => {

            }).finally(() => {
                btn_loading("new_seccion_content", 'Nuevo', 'hide')
            })
        },
        onEvaSeccionList: async function () {
            await axios.get(`../v2/api/FormacionEva/EvaSeccionList/${this.idCF_EvaluacionVersion}`, null, null).then(response => {
                this.secciones = response.data
            }).catch(error => {

            }).finally(() => {
            })
            
        }
    }
})

const admin_evaluacion = {
    template: `
<div>
    <div class="contact-sidebar">
        <div class="contact-sidebar-header">
            <i data-feather="search"></i>
            <div class="search-form">
                <input type="search" class="form-control" placeholder="buscar... eva">
            </div>
            <evaluacion-btn-add v-on:addNew="addNew"></evaluacion-btn-add>
        </div><!-- contact-sidebar-header -->
        <div class="contact-sidebar-body">
            <evaluacion-templates ref="list_evaluaciones"></evaluacion-templates>
        </div><!-- contact-sidebar-body -->
    </div><!-- contact-sidebar -->
    <router-view></router-view>
</div>`
    ,
    mounted() {
        new PerfectScrollbar('.contact-sidebar-body', {
            suppressScrollX: true
        });
    },
    methods: {
        addNew: function (newformacion) {
            this.$refs.list_evaluaciones.evaluaciones.push(newformacion);
        }
    }
}

const admin_evaluacion_design = {
    template: `
<div class="contact-content">
    <div class="contact-content-header">
        <nav class="nav">
            <router-link v-for="(version, version_index) in versiones" :to="{ name: 'admin-evaluacion-design-version', params: { idCF_EvaluacionVersion : version.idCF_EvaluacionVersion, idCF_Evaluacion: $route.params.idCF_Evaluacion }}"
                :class="'nav-link ' + (parseInt($route.params.idCF_EvaluacionVersion) === version.idCF_EvaluacionVersion ? 'active' : '')">
                {{version.folio}} <i class="fas fa-swatchbook"></i>
            </router-link>
        </nav>
        <a href="" id="contactOptions" class="text-secondary mg-l-auto"></a>
        <version-btn-add-evaluacion  class="ml-2" :idCF_Evaluacion="$route.params.idCF_Evaluacion" v-on:addNew="addNew"></version-btn-add-evaluacion>
    </div><!-- contact-content-header -->
    <router-view></router-view>
    <evaluacion-actions :idCF_Evaluacion="$route.params.idCF_Evaluacion"></evaluacion-actions>
</div><!-- contact-content -->
    `,
    data: function () {
        return {
            versiones: []
        }
    },
    watch: {
        $route(to, from) {
            if (to.params.idCF_Evaluacion !== from.params.idCF_Evaluacion) {
                this.onEvaVersionList();
            }
        }
    },
    mounted() {
        this.onEvaVersionList();
    },
    methods: {
        addNew: function (newObj) {
            this.versiones.push(newObj)
        },
        onEvaVersionList: async function () {
            this.versiones = null
            await axios.get(`../v2/api/FormacionEva/EvaVersionList/${this.$route.params.idCF_Evaluacion}`, null, null).then(response => {
                this.versiones = response.data
            }).catch(error => {

            }).finally(() => {

            })
        }
    }
}

const admin_evaluacion_design_version = {
    template: `
<div class="contact-content-body">
    <div class="tab-content pd-20 pd-xl-25" style="height: auto;">
        <div class="d-flex align-items-center justify-content-between mg-b-30">
            <h6 class="tx-15 mg-b-0" v-if="version !== null && version.publicada === false">Esta versión no ha sido publicada</h6>
            <h6 class="tx-15 mg-b-0" v-if="version !== null && version.publicada === true">Fecha publicacion: {{ version.fechaPubli | datetime_calendar }}</h6>

            <div class="btn-group  d-flex" role="group" aria-label="Basic example"  v-if="version !== null">
                <button type="button" class="btn btn-white btn-sm" v-if="version !== null && version.publicada === false" v-on:click="onEvaVersionPublicar">Publicar</button>
                <div class="dropdown dropright">
                    <button class="btn btn-white btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                      <i class="icon ion-md-time mg-r-5 tx-16 lh--9"></i>
                    </button>
                    <div class="dropdown-menu tx-13">
                      <div class="wd-400 pd-15">
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Versión</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.folio }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Comentarios</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.comentarios }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Instrucciones</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.instrucciones }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Mostrar preguntas aleatoriamente</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.aleatory ? 'Si' : 'No' }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Evaluacion organizada por secciones</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.bySecciones ? 'Si' : 'No' }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10 mt-2">Fe.Creación</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.createdAt | datetime_calendar }}
                        </p>
                        <label class="tx-10 tx-medium tx-spacing-1 tx-color-03 tx-uppercase tx-sans mg-b-10">Fe.Actualización</label>
                        <p class="tx-13 mg-b-0">
                            {{ version.updatedAt | datetime_calendar }}
                        </p>
                      </div>
                    </div>
                </div>
            </div><!-- btn-group -->
        </div><!-- d-flex -->
        <eva-version-secciones
            v-if="version !== null && version.bySecciones"
            :idCF_Evaluacion="$route.params.idCF_Evaluacion"
            :idCF_EvaluacionVersion="$route.params.idCF_EvaluacionVersion"
            :publicada="version.publicada"
        ></eva-version-secciones>
        <eva-version-preguntas
            v-if="version !== null && version.bySecciones === false"
            :idCF_Evaluacion="$route.params.idCF_Evaluacion"
            :idCF_EvaluacionVersion="$route.params.idCF_EvaluacionVersion"
            :publicada="version.publicada"
        ></eva-version-preguntas>
        
    </div><!-- tab-content -->
</div><!-- contact-content-body -->
`,
    data: function () {
        return {
            version: null,
            preguntas: [],
            selected: 0
        }
    },
    watch: {
        $route(to, from) {
            if (to.params.idCF_Evaluacion !== from.params.idCF_Evaluacion || to.params.idCF_EvaluacionVersion !== from.params.idCF_EvaluacionVersion) {
                this.onEvaVersionDetails();
                //this.onListContenidos();
            }
        }
    },
    mounted() {
        this.onEvaVersionDetails();
        //this.onListContenidos();
        new PerfectScrollbar('.contact-content-body', {
            suppressScrollX: true
        });
    },
    methods: {
        onEvaVersionPublicar: async function () {
            await axios.get(`../v2/api/FormacionEva/EvaVersionPublicar/${this.$route.params.idCF_Evaluacion}/${this.$route.params.idCF_EvaluacionVersion}`, null, null).then(response => {
                this.version.publicada = true
            }).catch(error => {

            }).finally(() => {

            })
        },
        onEvaVersionDetails: async function () {
            this.version = null
            await axios.get(`../v2/api/FormacionEva/EvaVersionDetails/${this.$route.params.idCF_Evaluacion}/${this.$route.params.idCF_EvaluacionVersion}`, null, null).then(response => {
                this.version = response.data
            }).catch(error => {

            }).finally(() => {

            })
        },
    }
}

const routes = [
    {
        path: '/',
        name: 'principal',
        component: principal,
        children: [
            {
                path: '/admin-formacion',
                name: 'admin-formacion',
                component: admin_formacion,
                children: [
                    {
                        path: '/admin-formacion/:idCF_Formacion',
                        name: 'admin-formacion-design',
                        component: admin_formacion_design,
                        children: [
                            {
                                path: '/admin-formacion/:idCF_Formacion/version/:idCF_Version',
                                name: 'admin-formacion-design-version',
                                component: admin_formacion_design_version,
                            }
                        ]
                    }
                ]
            },
            {
                path: '/admin-evaluacion',
                name: 'admin-evaluacion',
                component: admin_evaluacion,
                children: [
                    {
                        path: '/admin-evaluacion/:idCF_Evaluacion',
                        name: 'admin-evaluacion-design',
                        component: admin_evaluacion_design,
                        children: [
                            {
                                path: '/admin-evaluacion/:idCF_Evaluacion/version/:idCF_EvaluacionVersion',
                                name: 'admin-evaluacion-design-version',
                                component: admin_evaluacion_design_version,
                            }
                        ]
                    }
                ]
            },
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
