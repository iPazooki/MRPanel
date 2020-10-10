///<reference path="node_modules/abp-web-resources/Abp/Framework/scripts/abp.d.ts"/>

// Typings reference file, see links for more information
// https://github.com/typings/typings
// https://www.typescriptlang.org/docs/handbook/writing-declaration-files.html

declare var System: any;
declare var Push: any;

declare namespace abp {
  namespace ui {
    function setBusy(elm?: any, text?: any, delay?: any): void;
    function clearBusy(elm?: any, delay?: any): void;
  }
}

declare module '@ckeditor/ckeditor5-build-classic' {
	const ClassicEditor: any;

	export = ClassicEditor;
}
