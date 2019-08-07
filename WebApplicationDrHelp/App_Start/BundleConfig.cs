using System.Web.Optimization;

namespace WebApplicationDrHelp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterLayout(bundles);

            RegisterShared(bundles);

            RegisterAccount(bundles);

            RegisterHome(bundles);

            RegisterCharts(bundles);

            RegisterWidgets(bundles);

            RegisterElements(bundles);

            RegisterForms(bundles);

            RegisterTables(bundles);

            RegisterCalendar(bundles);

            RegisterMailbox(bundles);

            RegisterExamples(bundles);

            RegisterDocumentation(bundles);

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/style.css",
                      "~/Content/common/style.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // jQueryUI CSS
            bundles.Add(new ScriptBundle("~/Scripts/plugins/jquery-ui/jqueryuiStyles").Include(
                        "~/Scripts/plugins/jquery-ui/jquery-ui.css"));

            // jQueryUI 
            bundles.Add(new StyleBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/plugins/jquery-ui/jquery-ui.min.js"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/plugins/metisMenu/metisMenu.min.js",
                      "~/Scripts/plugins/pace/pace.min.js",
                      "~/Scripts/app/inspinia.js"));

            // Inspinia skin config script
            bundles.Add(new ScriptBundle("~/bundles/skinConfig").Include(
                      "~/Scripts/app/skin.config.min.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"));

            // Peity
            bundles.Add(new ScriptBundle("~/plugins/peity").Include(
                      "~/Scripts/plugins/peity/jquery.peity.min.js"));

            // Video responsible
            bundles.Add(new ScriptBundle("~/plugins/videoResponsible").Include(
                      "~/Scripts/plugins/video/responsible-video.js"));

            // Lightbox gallery css styles
            bundles.Add(new StyleBundle("~/Content/plugins/blueimp/css/").Include(
                      "~/Content/plugins/blueimp/css/blueimp-gallery.min.css"));

            // Lightbox gallery
            bundles.Add(new ScriptBundle("~/plugins/lightboxGallery").Include(
                      "~/Scripts/plugins/blueimp/jquery.blueimp-gallery.min.js"));

            // Sparkline
            bundles.Add(new ScriptBundle("~/plugins/sparkline").Include(
                      "~/Scripts/plugins/sparkline/jquery.sparkline.min.js"));

            // Morriss chart css styles
            bundles.Add(new StyleBundle("~/plugins/morrisStyles").Include(
                      "~/Content/plugins/morris/morris-0.4.3.min.css"));

            // Morriss chart
            bundles.Add(new ScriptBundle("~/plugins/morris").Include(
                      "~/Scripts/plugins/morris/raphael-2.1.0.min.js",
                      "~/Scripts/plugins/morris/morris.js"));

            // Flot chart
            bundles.Add(new ScriptBundle("~/plugins/flot").Include(
                      "~/Scripts/plugins/flot/jquery.flot.js",
                      "~/Scripts/plugins/flot/jquery.flot.tooltip.min.js",
                      "~/Scripts/plugins/flot/jquery.flot.resize.js",
                      "~/Scripts/plugins/flot/jquery.flot.pie.js",
                      "~/Scripts/plugins/flot/jquery.flot.time.js",
                      "~/Scripts/plugins/flot/jquery.flot.spline.js"));

            // Rickshaw chart
            bundles.Add(new ScriptBundle("~/plugins/rickshaw").Include(
                      "~/Scripts/plugins/rickshaw/vendor/d3.v3.js",
                      "~/Scripts/plugins/rickshaw/rickshaw.min.js"));

            // ChartJS chart
            bundles.Add(new ScriptBundle("~/plugins/chartJs").Include(
                      "~/Scripts/plugins/chartjs/Chart.min.js"));

            // iCheck css styles
            bundles.Add(new StyleBundle("~/Content/plugins/iCheck/iCheckStyles").Include(
                      "~/Content/plugins/iCheck/custom.css"));

            // iCheck
            bundles.Add(new ScriptBundle("~/plugins/iCheck").Include(
                      "~/Scripts/plugins/iCheck/icheck.min.js"));

            // dataTables css styles
            bundles.Add(new StyleBundle("~/Content/plugins/dataTables/dataTablesStyles").Include(
                      "~/Content/plugins/dataTables/datatables.min.css"));

            // dataTables 
            bundles.Add(new ScriptBundle("~/plugins/dataTables").Include(
                      "~/Scripts/plugins/dataTables/datatables.min.js",
                      "~/Scripts/common/jquery.fileDownload.js",
                      "~/Scripts/common/dataTablesPlugin.js"));

            // jeditable 
            bundles.Add(new ScriptBundle("~/plugins/jeditable").Include(
                      "~/Scripts/plugins/jeditable/jquery.jeditable.js"));

            // jqGrid styles
            bundles.Add(new StyleBundle("~/Content/plugins/jqGrid/jqGridStyles").Include(
                      "~/Content/plugins/jqGrid/ui.jqgrid.css"));

            // jqGrid 
            bundles.Add(new ScriptBundle("~/plugins/jqGrid").Include(
                      "~/Scripts/plugins/jqGrid/i18n/grid.locale-en.js",
                      "~/Scripts/plugins/jqGrid/jquery.jqGrid.min.js"));

            // codeEditor styles
            bundles.Add(new StyleBundle("~/plugins/codeEditorStyles").Include(
                      "~/Content/plugins/codemirror/codemirror.css",
                      "~/Content/plugins/codemirror/ambiance.css"));

            // codeEditor 
            bundles.Add(new ScriptBundle("~/plugins/codeEditor").Include(
                      "~/Scripts/plugins/codemirror/codemirror.js",
                      "~/Scripts/plugins/codemirror/mode/javascript/javascript.js"));

            // codeEditor 
            bundles.Add(new ScriptBundle("~/plugins/nestable").Include(
                      "~/Scripts/plugins/nestable/jquery.nestable.js"));

            // validate 
            bundles.Add(new ScriptBundle("~/plugins/validate").Include(
                      "~/Scripts/plugins/validate/jquery.validate.min.js"));

            // fullCalendar styles
            bundles.Add(new StyleBundle("~/plugins/fullCalendarStyles").Include(
                      "~/Content/plugins/fullcalendar/fullcalendar.css"));

            // fullCalendar 
            bundles.Add(new ScriptBundle("~/plugins/fullCalendar").Include(
                      "~/Scripts/plugins/fullcalendar/moment.min.js",
                      "~/Scripts/plugins/fullcalendar/fullcalendar.min.js"));

            // vectorMap 
            bundles.Add(new ScriptBundle("~/plugins/vectorMap").Include(
                      "~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                      "~/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"));

            // ionRange styles
            bundles.Add(new StyleBundle("~/Content/plugins/ionRangeSlider/ionRangeStyles").Include(
                      "~/Content/plugins/ionRangeSlider/ion.rangeSlider.css",
                      "~/Content/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css"));

            // ionRange 
            bundles.Add(new ScriptBundle("~/plugins/ionRange").Include(
                      "~/Scripts/plugins/ionRangeSlider/ion.rangeSlider.min.js"));

            // dataPicker styles
            bundles.Add(new StyleBundle("~/plugins/dataPickerStyles").Include(
                      "~/Content/plugins/datapicker/datepicker3.css"));

            // dataPicker 
            bundles.Add(new ScriptBundle("~/plugins/dataPicker").Include(
                      "~/Scripts/plugins/datapicker/bootstrap-datepicker.js"));

            // nouiSlider styles
            bundles.Add(new StyleBundle("~/plugins/nouiSliderStyles").Include(
                      "~/Content/plugins/nouslider/jquery.nouislider.css"));

            // nouiSlider 
            bundles.Add(new ScriptBundle("~/plugins/nouiSlider").Include(
                      "~/Scripts/plugins/nouslider/jquery.nouislider.min.js"));

            // jasnyBootstrap styles
            bundles.Add(new StyleBundle("~/plugins/jasnyBootstrapStyles").Include(
                      "~/Content/plugins/jasny/jasny-bootstrap.min.css"));//TODO David: eliminar

            // jasnyBootstrap 
            bundles.Add(new ScriptBundle("~/plugins/jasnyBootstrap").Include(
                      "~/Scripts/plugins/jasny/jasny-bootstrap.min.js"));

            // switchery styles
            bundles.Add(new StyleBundle("~/plugins/switcheryStyles").Include(
                      "~/Content/plugins/switchery/switchery.css"));

            // switchery 
            bundles.Add(new ScriptBundle("~/plugins/switchery").Include(
                      "~/Scripts/plugins/switchery/switchery.js"));

            // chosen styles
            bundles.Add(new StyleBundle("~/Content/plugins/chosen/chosenStyles").Include(
                      "~/Content/plugins/chosen/chosen.css"));

            // chosen 
            bundles.Add(new ScriptBundle("~/plugins/chosen").Include(
                      "~/Scripts/plugins/chosen/chosen.jquery.js"));

            // knob 
            bundles.Add(new ScriptBundle("~/plugins/knob").Include(
                      "~/Scripts/plugins/jsKnob/jquery.knob.js"));

            // wizardSteps styles
            bundles.Add(new StyleBundle("~/plugins/wizardStepsStyles").Include(
                      "~/Content/plugins/steps/jquery.steps.css"));

            // wizardSteps 
            bundles.Add(new ScriptBundle("~/plugins/wizardSteps").Include(
                      "~/Scripts/plugins/staps/jquery.steps.min.js"));

            // dropZone styles
            bundles.Add(new StyleBundle("~/Content/plugins/dropzone/dropZoneStyles").Include(
                      "~/Content/plugins/dropzone/basic.css",
                      "~/Content/plugins/dropzone/dropzone.css"));

            // dropZone 
            bundles.Add(new ScriptBundle("~/plugins/dropZone").Include(
                      "~/Scripts/plugins/dropzone/dropzone.js"));

            // summernote styles
            bundles.Add(new StyleBundle("~/plugins/summernoteStyles").Include(
                      "~/Content/plugins/summernote/summernote.css",
                      "~/Content/plugins/summernote/summernote-bs3.css"));

            // summernote 
            bundles.Add(new ScriptBundle("~/plugins/summernote").Include(
                      "~/Scripts/plugins/summernote/summernote.min.js"));

            // toastr notification 
            bundles.Add(new ScriptBundle("~/plugins/toastr").Include(
                      "~/Scripts/plugins/toastr/toastr.min.js"));

            // toastr notification styles
            bundles.Add(new StyleBundle("~/plugins/toastrStyles").Include(
                      "~/Content/plugins/toastr/toastr.min.css"));

            // color picker
            bundles.Add(new ScriptBundle("~/plugins/colorpicker").Include(
                      "~/Scripts/plugins/colorpicker/bootstrap-colorpicker.min.js"));

            // color picker styles
            bundles.Add(new StyleBundle("~/Content/plugins/colorpicker/colorpickerStyles").Include(
                      "~/Content/plugins/colorpicker/bootstrap-colorpicker.min.css"));

            // image cropper
            bundles.Add(new ScriptBundle("~/plugins/imagecropper").Include(
                      "~/Scripts/plugins/cropper/cropper.min.js"));

            // image cropper styles
            bundles.Add(new StyleBundle("~/plugins/imagecropperStyles").Include(
                      "~/Content/plugins/cropper/cropper.min.css"));

            // jsTree
            bundles.Add(new ScriptBundle("~/plugins/jsTree").Include(
                      "~/Scripts/plugins/jsTree/jstree.min.js"));

            // jsTree styles
            bundles.Add(new StyleBundle("~/Content/plugins/jsTree").Include(
                      "~/Content/plugins/jsTree/style.css"));

            // Diff
            bundles.Add(new ScriptBundle("~/plugins/diff").Include(
                      "~/Scripts/plugins/diff_match_patch/javascript/diff_match_patch.js",
                      "~/Scripts/plugins/preetyTextDiff/jquery.pretty-text-diff.min.js"));

            // Idle timer
            bundles.Add(new ScriptBundle("~/plugins/idletimer").Include(
                      "~/Scripts/plugins/idle-timer/idle-timer.min.js"));

            // Tinycon
            bundles.Add(new ScriptBundle("~/plugins/tinycon").Include(
                      "~/Scripts/plugins/tinycon/tinycon.min.js"));

            // Chartist
            bundles.Add(new StyleBundle("~/plugins/chartistStyles").Include(
                      "~/Content/plugins/chartist/chartist.min.css"));

            // jsTree styles
            bundles.Add(new ScriptBundle("~/plugins/chartist").Include(
                      "~/Scripts/plugins/chartist/chartist.min.js"));

            // Awesome bootstrap checkbox
            bundles.Add(new StyleBundle("~/plugins/awesomeCheckboxStyles").Include(
                      "~/Content/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"));

            // Clockpicker styles
            bundles.Add(new StyleBundle("~/plugins/clockpickerStyles").Include(
                      "~/Content/plugins/clockpicker/clockpicker.css"));

            // Clockpicker
            bundles.Add(new ScriptBundle("~/plugins/clockpicker").Include(
                      "~/Scripts/plugins/clockpicker/clockpicker.js"));

            // Date range picker Styless
            bundles.Add(new StyleBundle("~/plugins/dateRangeStyles").Include(
                      "~/Content/plugins/daterangepicker/daterangepicker-bs3.css"));

            // Date range picker
            bundles.Add(new ScriptBundle("~/plugins/dateRange").Include(
                      // Date range use moment.js same as full calendar plugin 
                      "~/Scripts/plugins/fullcalendar/moment.min.js",
                      "~/Scripts/plugins/daterangepicker/daterangepicker.js"));

            // Sweet alert Styless
            bundles.Add(new StyleBundle("~/plugins/sweetAlertStyles").Include(
                      "~/Content/plugins/sweetalert/sweetalert.css"));

            // Sweet alert
            bundles.Add(new ScriptBundle("~/plugins/sweetAlert").Include(
                      "~/Scripts/plugins/sweetalert/sweetalert.min.js"));

            // Footable Styless
            bundles.Add(new StyleBundle("~/plugins/footableStyles").Include(
                      "~/Content/plugins/footable/footable.core.css", new CssRewriteUrlTransform()));

            // Footable alert
            bundles.Add(new ScriptBundle("~/plugins/footable").Include(
                      "~/Scripts/plugins/footable/footable.all.min.js"));

            // Select2 Styless
            bundles.Add(new StyleBundle("~/plugins/select2Styles").Include(
                      "~/Content/plugins/select2/select2.min.css"));

            // Select2
            bundles.Add(new ScriptBundle("~/plugins/select2").Include(
                      "~/Scripts/plugins/select2/select2.full.min.js"));

            // Masonry
            bundles.Add(new ScriptBundle("~/plugins/masonry").Include(
                      "~/Scripts/plugins/masonary/masonry.pkgd.min.js"));

            // Slick carousel Styless
            bundles.Add(new StyleBundle("~/plugins/slickStyles").Include(
                      "~/Content/plugins/slick/slick.css", new CssRewriteUrlTransform()));

            // Slick carousel theme Styless
            bundles.Add(new StyleBundle("~/plugins/slickThemeStyles").Include(
                      "~/Content/plugins/slick/slick-theme.css", new CssRewriteUrlTransform()));

            // Slick carousel
            bundles.Add(new ScriptBundle("~/plugins/slick").Include(
                      "~/Scripts/plugins/slick/slick.min.js"));

            // Ladda buttons Styless
            bundles.Add(new StyleBundle("~/plugins/laddaStyles").Include(
                      "~/Content/plugins/ladda/ladda-themeless.min.css"));

            // Ladda buttons
            bundles.Add(new ScriptBundle("~/plugins/ladda").Include(
                      "~/Scripts/plugins/ladda/spin.min.js",
                      "~/Scripts/plugins/ladda/ladda.min.js",
                      "~/Scripts/plugins/ladda/ladda.jquery.min.js"));

            // Dotdotdot buttons
            bundles.Add(new ScriptBundle("~/plugins/truncate").Include(
                      "~/Scripts/plugins/dotdotdot/jquery.dotdotdot.min.js"));

            // Touch Spin Styless
            bundles.Add(new StyleBundle("~/plugins/touchSpinStyles").Include(
                      "~/Content/plugins/touchspin/jquery.bootstrap-touchspin.min.css"));

            // Touch Spin
            bundles.Add(new ScriptBundle("~/plugins/touchSpin").Include(
                      "~/Scripts/plugins/touchspin/jquery.bootstrap-touchspin.min.js"));

            // Tour Styless
            bundles.Add(new StyleBundle("~/plugins/tourStyles").Include(
                      "~/Content/plugins/bootstrapTour/bootstrap-tour.min.css"));

            // Tour Spin
            bundles.Add(new ScriptBundle("~/plugins/tour").Include(
                      "~/Scripts/plugins/bootstrapTour/bootstrap-tour.min.js"));

            // i18next Spin
            bundles.Add(new ScriptBundle("~/plugins/i18next").Include(
                      "~/Scripts/plugins/i18next/i18next.min.js"));

            // Clipboard Spin
            bundles.Add(new ScriptBundle("~/plugins/clipboard").Include(
                      "~/Scripts/plugins/clipboard/clipboard.min.js"));

            // c3 Styless
            bundles.Add(new StyleBundle("~/plugins/c3Styles").Include(
                      "~/Content/plugins/c3/c3.min.css"));

            // c3 Spin
            bundles.Add(new ScriptBundle("~/plugins/c3").Include(
                      "~/Scripts/plugins/c3/c3.min.js"));

            // d3 Spin
            bundles.Add(new ScriptBundle("~/plugins/d3").Include(
                      "~/Scripts/plugins/d3/d3.min.js"));

            // Markdown Styless
            bundles.Add(new StyleBundle("~/plugins/markdownStyles").Include(
                      "~/Content/plugins/bootstrap-markdown/bootstrap-markdown.min.css"));

            // Markdown Spin
            bundles.Add(new ScriptBundle("~/plugins/markdown").Include(
                      "~/Scripts/plugins/bootstrap-markdown/bootstrap-markdown.js",
                      "~/Scripts/plugins/bootstrap-markdown/markdown.js"));

            //Common utilities 
            bundles.Add(new ScriptBundle("~/common/utilities").Include(
                     "~/Scripts/common/utilities.js"
                   ));

            // Bootstrap Validator http://1000hz.github.io/bootstrap-validator/#validator-fields
            // Si se incluye remplaza validador por defecto de Bootstrap
            bundles.Add(new ScriptBundle("~/plugins/validator").Include(
                      "~/Scripts/plugins/bootstrap-validator/validator.js"));


        }

        private static void RegisterDocumentation(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Documentation/menu").Include(
                "~/Scripts/Documentation/Documentation-menu.js"));
        }

        private static void RegisterExamples(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Examples/Blank/menu").Include(
                "~/Scripts/Examples/Blank-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Invoice/menu").Include(
                "~/Scripts/Examples/Invoice-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Lockscreen/menu").Include(
                "~/Scripts/Examples/Lockscreen-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Login").Include(
                "~/Scripts/Examples/Login.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Login/menu").Include(
                "~/Scripts/Examples/Login-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/P404/menu").Include(
                "~/Scripts/Examples/P404-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/P500/menu").Include(
                "~/Scripts/Examples/P500-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Pace").Include(
                "~/Scripts/Examples/Pace.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Pace/menu").Include(
                "~/Scripts/Examples/Pace-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/ProfileEx/menu").Include(
                "~/Scripts/Examples/ProfileEx-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Register").Include(
                "~/Scripts/Examples/Register.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Register/menu").Include(
                "~/Scripts/Examples/Register-menu.js"));
        }

        private static void RegisterMailbox(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Inbox").Include(
                "~/Scripts/Mailbox/Inbox.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Inbox/menu").Include(
                "~/Scripts/Mailbox/Inbox-menu.js"));
            
            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Compose").Include(
                "~/Scripts/Mailbox/Compose.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Compose/menu").Include(
               "~/Scripts/Mailbox/Compose-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Read/menu").Include(
                "~/Scripts/Mailbox/Read-menu.js"));
        }

        private static void RegisterCalendar(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Calendar").Include(
                "~/Scripts/Calendar/Calendar.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Calendar/menu").Include(
                "~/Scripts/Calendar/Calendar-menu.js"));
        }

        private static void RegisterTables(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Tables/Simple/menu").Include(
                "~/Scripts/Tables/Simple-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Tables/Data").Include(
                "~/Scripts/Tables/Data.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Tables/Data/menu").Include(
                "~/Scripts/Tables/Data-menu.js"));
        }

        private static void RegisterForms(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Forms/Advanced").Include(
                "~/Scripts/Forms/Advanced.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Forms/Advanced/menu").Include(
                "~/Scripts/Forms/Advanced-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Forms/Editors").Include(
                "~/Scripts/Forms/Editors.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Forms/Editors/menu").Include(
                "~/Scripts/Forms/Editors-menu.js"));


            bundles.Add(new ScriptBundle("~/Scripts/Forms/General/menu").Include(
                "~/Scripts/Forms/General-menu.js"));
        }

        private static void RegisterElements(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Elements/Buttons/menu").Include(
                "~/Scripts/Elements/Buttons-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/General/menu").Include(
                "~/Scripts/Elements/General-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/General").Include(
                "~/Styles/Elements/General.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Icons/menu").Include(
                "~/Scripts/Elements/Icons-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/Icons").Include(
                "~/Styles/Elements/Icons.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Modals/menu").Include(
                "~/Scripts/Elements/Modals-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/Modals").Include(
                "~/Styles/Elements/Modals.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Sliders").Include(
                "~/Scripts/Elements/Sliders.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Sliders/menu").Include(
                "~/Scripts/Elements/Sliders-menu.js"));
            
            bundles.Add(new ScriptBundle("~/Scripts/Elements/Timeline/menu").Include(
                "~/Scripts/Elements/Timeline-menu.js"));
        }

        private static void RegisterWidgets(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Widgets/menu").Include(
                "~/Scripts/Widgets/Widgets-menu.js"));
        }

        private static void RegisterCharts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Charts/ChartsJs").Include(
                "~/Scripts/Charts/ChartsJs.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Charts/ChartsJs/menu").Include(
                            "~/Scripts/Charts/ChartsJs-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Morris").Include(
                "~/Scripts/Charts/Morris.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Morris/menu").Include(
                "~/Scripts/Charts/Morris-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Flot").Include(
                "~/Scripts/Charts/Flot.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Flot/menu").Include(
                "~/Scripts/Charts/Flot-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Inline").Include(
                "~/Scripts/Charts/Inline.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Inline/menu").Include(
                "~/Scripts/Charts/Inline-menu.js"));
        }

        private static void RegisterHome(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV1").Include(
                "~/Scripts/Home/DashboardV1.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV1/menu").Include(
                "~/Scripts/Home/DashboardV1-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV2").Include(
                "~/Scripts/Home/DashboardV2.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV2/menu").Include(
                "~/Scripts/Home/DashboardV2-menu.js"));
        }

        private static void RegisterAccount(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Account/Login").Include(
                "~/Scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Account/Register").Include(
                "~/Scripts/Account/Register.js"));
        }

        private static void RegisterShared(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Shared/_Layout").Include(
                "~/Scripts/Shared/_Layout.js"));
        }

        private static void RegisterLayout(BundleCollection bundles)
        {
            // bootstrap
            bundles.Add(new ScriptBundle("~/AdminLTE/bootstrap/js").Include(
                "~/AdminLTE/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/bootstrap/css").Include(
                "~/AdminLTE/bootstrap/css/bootstrap.min.css"));
            
            // dist
            bundles.Add(new ScriptBundle("~/AdminLTE/dist/js").Include(
                "~/AdminLTE/dist/js/app.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/dist/css").Include(
                "~/AdminLTE/dist/css/admin-lte.min.css"));

            bundles.Add(new StyleBundle("~/AdminLTE/dist/css/skins").Include(
                "~/AdminLTE/dist/css/skins/_all-skins.min.css"));

            // documentation
            bundles.Add(new ScriptBundle("~/AdminLTE/documentation/js").Include(
                "~/AdminLTE/documentation/js/docs.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/documentation/css").Include(
                "~/AdminLTE/documentation/css/style.css"));

            // plugins | bootstrap-slider
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/bootstrap-slider/js").Include(
                                        "~/AdminLTE/plugins/bootstrap-slider/js/bootstrap-slider.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/bootstrap-slider/css").Include(
                                        "~/AdminLTE/plugins/bootstrap-slider/css/slider.css"));

            // plugins | bootstrap-wysihtml5
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/bootstrap-wysihtml5/js").Include(
                                         "~/AdminLTE/plugins/bootstrap-wysihtml5/js/bootstrap3-wysihtml5.all.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/bootstrap-wysihtml5/css").Include(
                                        "~/AdminLTE/plugins/bootstrap-wysihtml5/css/bootstrap3-wysihtml5.min.css"));

            // plugins | chartjs
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/chartjs/js").Include(
                                         "~/AdminLTE/plugins/chartjs/js/chart.min.js"));

            // plugins | ckeditor
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/ckeditor/js").Include(
                                         "~/AdminLTE/plugins/ckeditor/js/ckeditor.js"));

            // plugins | colorpicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/colorpicker/js").Include(
                                         "~/AdminLTE/plugins/colorpicker/js/bootstrap-colorpicker.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/colorpicker/css").Include(
                                        "~/AdminLTE/plugins/colorpicker/css/bootstrap-colorpicker.css"));

            // plugins | datatables
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/datatables/js").Include(
                                         "~/AdminLTE/plugins/datatables/js/jquery.dataTables.min.js",
                                          "~/AdminLTE/plugins/datatables/js/extensions/AutoFill/js/dataTables.autoFill.min.min.js",
                                           "~/AdminLTE/plugins/datatables/js/extensions/AutoFill/js/dataTables.autoFill.js",
                                         "~/AdminLTE/plugins/datatables/js/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/datatables/css").Include(
                                        "~/AdminLTE/plugins/datatables/css/dataTables.bootstrap.css"));

            // plugins | datepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/datepicker/js").Include(
                                         "~/AdminLTE/plugins/datepicker/js/bootstrap-datepicker.js",
                                         "~/AdminLTE/plugins/datepicker/js/locales/bootstrap-datepicker*"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/datepicker/css").Include(
                                        "~/AdminLTE/plugins/datepicker/css/datepicker3.css"));

            // plugins | daterangepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/daterangepicker/js").Include(
                                         "~/AdminLTE/plugins/daterangepicker/js/moment.min.js",
                                         "~/AdminLTE/plugins/daterangepicker/js/daterangepicker.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/daterangepicker/css").Include(
                                        "~/AdminLTE/plugins/daterangepicker/css/daterangepicker-bs3.css"));

            // plugins | fastclick
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/fastclick/js").Include(
                                         "~/AdminLTE/plugins/fastclick/js/fastclick.min.js"));

            // plugins | flot
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/flot/js").Include(
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.resize.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.pie.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.categories.min.js"));

            // plugins | font-awesome
            bundles.Add(new StyleBundle("~/AdminLTE/plugins/font-awesome/css").Include(
                                        "~/AdminLTE/plugins/font-awesome/css/font-awesome.min.css"));

            // plugins | fullcalendar
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/fullcalendar/js").Include(
                                         "~/AdminLTE/plugins/fullcalendar/js/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/fullcalendar/css").Include(
                                        "~/AdminLTE/plugins/fullcalendar/css/fullcalendar.min.css"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/fullcalendar/css/print").Include(
                                        "~/AdminLTE/plugins/fullcalendar/css/print/fullcalendar.print.css"));

            // plugins | icheck
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/icheck/js").Include(
                                         "~/AdminLTE/plugins/icheck/js/icheck.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/icheck/css").Include(
                                        "~/AdminLTE/plugins/icheck/css/all.css"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/icheck/css/flat").Include(
                                        "~/AdminLTE/plugins/icheck/css/flat/flat.css"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/icheck/css/sqare/blue").Include(
                                        "~/AdminLTE/plugins/icheck/css/sqare/blue.css"));

            // plugins | input-mask
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/input-mask/js").Include(
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.js",
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.date.extensions.js",
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.extensions.js"));

            // plugins | ionicons
            bundles.Add(new StyleBundle("~/AdminLTE/plugins/ionicons/css").Include(
                                        "~/AdminLTE/plugins/ionicons/css/ionicons.min.css"));

            // plugins | ionslider
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/ionslider/js").Include(
                                         "~/AdminLTE/plugins/ionslider/js/ion.rangeSlider.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/ionslider/css").Include(
                                        "~/AdminLTE/plugins/ionslider/css/ion.rangeSlider.css",
                                        "~/AdminLTE/plugins/ionslider/css/ion.rangeSlider.skinNice.css"));

            // plugins | jquery
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery/js").Include(
                                         "~/AdminLTE/plugins/jquery/js/jQuery-2.1.4.min.js"));

            // plugins | jquery-validate
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery-validate/js").Include(
                                         "~/AdminLTE/plugins/jquery-validate/js/jquery.validate*"));

            // plugins | jquery-ui
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery-ui/js").Include(
                                         "~/AdminLTE/plugins/jquery-ui/js/jquery-ui.min.js"));

            // plugins | jvectormap
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jvectormap/js").Include(
                                         "~/AdminLTE/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                                         "~/AdminLTE/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/jvectormap/css").Include(
                                        "~/AdminLTE/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css"));

            // plugins | knob
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/knob/js").Include(
                                         "~/AdminLTE/plugins/knob/js/jquery.knob.js"));

            // plugins | morris
            bundles.Add(new StyleBundle("~/AdminLTE/plugins/morris/css").Include(
                                        "~/AdminLTE/plugins/morris/css/morris.css"));

            // plugins | momentjs
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/momentjs/js").Include(
                                         "~/AdminLTE/plugins/momentjs/js/moment.min.js"));

            // plugins | pace
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/pace/js").Include(
                                         "~/AdminLTE/plugins/pace/js/pace.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/pace/css").Include(
                                        "~/AdminLTE/plugins/pace/css/pace.min.css"));

            // plugins | slimscroll
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/slimscroll/js").Include(
                                         "~/AdminLTE/plugins/slimscroll/js/jquery.slimscroll.min.js"));

            // plugins | sparkline
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/sparkline/js").Include(
                                         "~/AdminLTE/plugins/sparkline/js/jquery.sparkline.min.js"));

            // plugins | timepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/timepicker/js").Include(
                                         "~/AdminLTE/plugins/timepicker/js/bootstrap-timepicker.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/timepicker/css").Include(
                                        "~/AdminLTE/plugins/timepicker/css/bootstrap-timepicker.min.css"));

            // plugins | raphael
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/raphael/js").Include(
                                         "~/AdminLTE/plugins/raphael/js/raphael-min.js"));

            // plugins | select2
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/select2/js").Include(
                                         "~/AdminLTE/plugins/select2/js/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/select2/css").Include(
                                        "~/AdminLTE/plugins/select2/css/select2.min.css"));

            // plugins | morris
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/morris/js").Include(
                                         "~/AdminLTE/plugins/morris/js/morris.min.js"));

        }
    }
}
