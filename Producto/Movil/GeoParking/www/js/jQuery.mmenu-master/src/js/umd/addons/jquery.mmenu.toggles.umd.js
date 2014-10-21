(function ( factory ) {
    if ( typeof define === 'function' && define.amd )
    {
        // AMD. Register as an anonymous module.
        define( [ 'jquery' ], factory );
    }
    else if ( typeof exports === 'object' )
    {
        // Node/CommonJS
        factory( require( 'jquery' ) );
    }
    else
    {
        // Browser globals
        factory( jQuery );
    }
}( function ( jQuery ) {


/*	
 * jQuery mmenu toggles addon
 * mmenu.frebsite.nl
 *
 * Copyright (c) Fred Heusschen
 */
!function(t){function s(t){return t}function e(t){return t}function a(){r=!0,n=t[c]._c,o=t[c]._d,l=t[c]._e,n.add("toggle check"),h=t[c].glbl}var c="mmenu",i="toggles";t[c].prototype["_init_"+i]=function(c){r||a();var o=this.vars[i+"_added"];this.vars[i+"_added"]=!0,o||(this.opts[i]=s(this.opts[i]),this.conf[i]=e(this.conf[i]));var l=this;this.opts[i],this.conf[i],this.__refactorClass(t("input",c),this.conf.classNames[i].toggle,"toggle"),this.__refactorClass(t("input",c),this.conf.classNames[i].check,"check"),t("input."+n.toggle,c).add("input."+n.check,c).each(function(){var s=t(this),e=s.closest("li"),a=s.hasClass(n.toggle)?"toggle":"check",c=s.attr("id")||l.__getUniqueId();e.children('label[for="'+c+'"]').length||(s.attr("id",c),e.prepend(s),t('<label for="'+c+'" class="'+n[a]+'"></label>').insertBefore(e.children("a, span").last()))})},t[c].addons.push(i),t[c].defaults[i]={},t[c].configuration.classNames[i]={toggle:"Toggle",check:"Check"};var n,o,l,h,r=!1}(jQuery);
}));