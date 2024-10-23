/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

    config.iframe_attributes = {
        sandbox: 'allow-same-origin allow-forms allow-scripts',
        allow: 'autoplay'
    }

    config.language = 'fa';
    config.filebrowserImageUploadUrl = '/Upload/ImageUploader';
    config.preset = 'full';

   
    config.contentsLangDirection = 'rtl';
    config.embed_provider= '//ckeditor.iframe.ly/api/oembed?url={url}&callback={callback}&consent=0';

   
    config.font_names = 'IRANSansWeb;baran;titr;homa;nazanin;yekan;' + config.font_names;

    config.extraPlugins = 'html5audio,tableresize,codesnippet,inserthtml4x,zoom,lineheight,wordcount,cssanim,' +
        'inserthtmlfile,html5video,youtube,chart,btgrid,embedbase,embed';
};



