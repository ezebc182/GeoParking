/*Permite que desde otra pagina se pueda acceder directamente a una seccion de la landpage*/

var url = document.URL;

if (url == "http://localhost:2893/Index.aspx#fea") {
    window.location = 'http://localhost:2893/Index.aspx#fea';
} else if (url == "http://localhost:2893/Index.aspx#gallery") {
    window.location = 'http://localhost:2893/Index.aspx#gallery';
} else if (url == "http://localhost:2893/Index.aspx#about") {
    window.location = 'http://localhost:2893/Index.aspx#about';
} else if (url == "http://localhost:2893/Index.aspx#contact") {
    window.location = 'http://localhost:2893/Index.aspx#contact';
}
