/*Permite que desde otra pagina se pueda acceder directamente a una seccion de la landpage*/

var url = document.URL;

if (url == "http://localhost:2893/web.aspx#fea") {
    window.location = 'http://localhost:2893/web.aspx#fea';
} else if (url == "http://localhost:2893/web.aspx#gallery") {
    window.location = 'http://localhost:2893/web.aspx#gallery';
} else if (url == "http://localhost:2893/web.aspx#about") {
    window.location = 'http://localhost:2893/web.aspx#about';
} else if (url == "http://localhost:2893/web.aspx#contact") {
    window.location = 'http://localhost:2893/web.aspx#contact';
}
