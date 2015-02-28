<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web2.Index" %>


<!DOCTYPE html>
<html lang="es">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta name="description" content="Sistema de geo estacionamiento">
	<!-- Template author -->
	<meta name="author" content="GeoParking">

	<!-- Favicon -->
	<link rel="shortcut icon" href="geoparking/images/favicon.ico">

	<!-- Website Title -->
	<title>GeoParking</title>

	<!-- Bootstrap core CSS -->
	<link href="geoparking/assets/css/bootstrap.css" rel="stylesheet">

	<!-- Custom styles for this template -->	
	<link href="geoparking/css/style.css" rel="stylesheet">

	<!-- Custom styles -->
	<link href="geoparking/css/custom.css" rel="stylesheet">	

	<!-- Font Awesome -->
	<link rel="stylesheet" href="geoparking/lib/font-awesome/css/font-awesome.min.css">


	<!-- Modernizr -->
	<script src="geoparking/assets/js/modernizr.custom.19252.js"></script>		
</head>

<body>

	<!-- Preloader -->
	<div class="loader"></div>
	<!-- End preloader -->

	<!-- Intro -->

	<div id="intro">
		<!-- Animated background -->

        <a href="#features" class="round-button">
         <i  id="flecha-abajo" class="fa fa-caret-down" data-toggle="tooltip" data-placement="top" title="Conocenos!"></i>
        </a>
        
		<div class="slideshow">
			<img class="img-responsive" src="geoparking/images/bgs/parking.jpg" alt="slide">
			<img class="img-responsive" src="geoparking/images/bgs/testimonials2.jpg" alt="slide">
			<img class="img-responsive" src="geoparking/images/bgs/intro.jpg" alt="slide">
		
            </div>
         
		<div class="container">
            <%--<div class="col-md-12">
            <a id="linkSesion" style="z-index:3;" href="web.aspx">
					<i id="iconoUsuario" class="fa fa-user"></i>&nbsp;Ingresar
			</a>
            </div>--%>
                
			<div class="col-md-7 col-sm-6">	

				<!-- Image logo -->
				<div class="logo">				
					
				</div>		

				<!-- App name, description & START button -->	
				<h1 class="uppercase" style="text-shadow: 4px 4px 13px rgb(30, 28, 28);"><span style="color: red;">Geo</span>Parking</h1>			
			<p style="text-shadow: 4px 4px 13px rgba(30, 28, 28 ,1);" class="intro-text">Estacioná de manera fácil, rápida y efectiva.</p>							
			<div class="">
				<%--<a id="start-btn"class="start-button uppercase" href="#features">
					<img src="geoparking/images/down.png" alt="conocenos">Conocenos!
				</a>--%>
				
				<a id="linkRegistrarPlaya" class="btn btn-info" href="/web.aspx">
					<i id="iconoBuscar" class="fa fa-search"></i>Buscar playa
				</a>
                <a id="linkBuscarPlaya" class="btn btn-default" href="/DatosDeRegistro.aspx">
					<i id="iconoRegistrar" class="fa fa-map-marker"></i>Registra tu playa!
                    
				</a>
			</div>
		</div>
            
		<!-- Smartphone slider -->		
		<div class="col-md-5 col-sm-6">
			<div class="introimg">

				<!-- Background slider image -->			
				<img src="geoparking/images/hand.png" alt="image">
				<img class="app-screen" src="geoparking/images/movil/mainPage.png" alt="smartphone" />

			</div>
		</div>	
		<!-- End Smartphone slider -->
	</div>
   
</div>

<!-- End intro-->		
<section id="cd-intro">
	<div id="cd-intro-tagline">
		<h1><!-- your tagline here --></h1>
		<a href="#0" class="cd-btn"><!-- your action button text here --></a>
	</div> 
</section>

<div class="cd-secondary-nav">
	<a href="#0" class="cd-secondary-nav-trigger">Menu<span></span></a> <!-- button visible on small devices -->
	<nav>
		<ul>
			<li>
				<a href="#features">
					<b>Qué es?</b>
					<span></span><!-- icon -->
				</a>
			</li>
			<li>
				<a href="#mobile">
					<b>App movil</b>
					<span></span><!-- icon -->
				</a>
			</li>
			<li>
				<a href="#our-team">
					<b>El equipo</b>
					<span></span><!-- icon -->
				</a>
			</li>
			<li>
				<a href="#contacto">
					<b>Contacto</b>
					<span></span><!-- icon -->
				</a>
			</li>
			
			<!-- other items here -->
		</ul>
	</nav>
</div> <!-- .cd-secondary-nav -->

 <div class="cd-main-content">

		<!-- Features -->
		<section id="features" class="cd-section cd-container feat-wrap" >
			<div class="container text-center">
				<h1 class="page-header">¿Que es GeoParking?</h1>
				<div class="jumbotron">
					<span>Es un sistema que brinda información sobre la localización de playas de estacionamiento registradas en una ciudad, facilitándole al usuario tanto de la aplicación <strong><a href="web.aspx" target="_blank">web</a></strong> como <strong><a href="#mobile">móvil</a></strong>, el tedioso trabajo de conseguir un lugar para estacionar su vehículo.</span>
				</div>
			</div>
			<div class="container">
				<div class="col-md-6">
					<h2>¿Cómo funciona?</h2>
                    <br />
					<span>
						Básicamente, el usuario busca en su ciudad playas de estacionamiento y GeoParking hace el resto!
						<br>
						Nuestro software, buscará en su ciudad playas de estacionamiento cercanas a donde se encuentre y le proporcionará información de su:
						<br/>
						<br/>
						<ul>
							<li>Nombre y dirección</li>
							<li>Precios</li>
							<li>Disponibilidad de lugares</li>
							<li>Y mucho más...</li>
						</ul>
						<br/>
                        <div class="well">
                        <strong>Para mayor información, te invitamos a que veas nuestro video comercial. </strong></div>
                        
				</div>
				<div class="col-md-6">
		<!-- HTML5 video	<video width="500" height="300"controls="controls"  poster="images/bgs/parking.jpg">
			<source src="http://youtu.be/kaPcI5_PTsk" type="video/mp4" />
			Tu navegador no es compatible con HTML5
			</video> -->
                    
			<div class="embed-responsive embed-responsive-16by9">
                <br />
                <iframe width="540" height="310" src="http://www.wideo.co/embed/8483391425130777112?height=300&width=500" frameborder="0"></iframe>
				
			</div>

			</div>


			</div><!-- Container -->	
		</section>
		<!-- End features -->

		<!-- Special features -->	
		<section id="mobile" class="cd-section cd-container container sp-features">
			<h1 class="text-center page-header">GeoParking móvil</h1>
			<!-- Left image -->
			<div class="col-md-6 text-center">
				<div class="slideMobile">
					<img src="geoparking/images/movil/pantalla-principal.JPG" alt="mobile">	
					<img src="geoparking/images/movil/panel-listado-playas.JPG" alt="mobile">	
					<img src="geoparking/images/movil/resultado-busqueda.JPG" alt="mobile">	
				</div>
			</div>	

			<!-- Right text -->
			<div class="col-md-6">
				<h2 >Principales características</h2>
				<br>
				<div class="special-ft-wrap">
					<i class="fa fa-map-marker ft-icon"></i>
					<h5>Geolocalización de playas</h5>
					<p>Con la tecnología de <strong>Google maps &reg;</strong>, podrá localizar playas de estacionamiento en su ciudad .</p>
					<div class="clear"></div>

					<i class="fa fa-car ft-icon"></i>
					<h5>Guardar la posición de tu vehículo</h5>
					<p>Para su tranquilidad, podrá guardar la posición de su vehículo, para luego poder consultarla y dirigirse hacia el punto de ubicación.</p>
					<div class="clear"></div>

					<i class="fa fa-road ft-icon"></i>
					<h5>Visualizar el trayecto</h5>
					<p>Podrá ver cómo llegar hacia su destino, paso por paso.</p>
					<div class="clear"></div>

					<i class="fa fa-search ft-icon"></i>
					<h5>Buscar puntos de interés</h5>
					<p>Localizar playas cercanas a un punto de interés: bancos, shoppings,correo, teatros, etc.</p>
					<div class="clear"></div>  

				<strong>Descargá el manual de usuario para mayor información:</strong>
                <a id="download-manual-app" class="btn btn-lg btn-primary" href="downloads/GP_ManualAppMóvil.pdf" target="_blank"><span class="fa fa-download"></span> &nbsp;Descargar</a>
                
                </div>
                
				
			</div>	
			
		</section>	

		<section id="download" class="jumbotron">
			<div class="container">
				<h3>Descargá GeoParking:</h3>
				<br>
					<div class="col-md-3 col-md-offset-1">
						<a href="#" target="_blank">
							<img class="download-img" src="geoparking/images/tiendas/play_logo_x2.png"/>
						</a>
					</div>
					<div class="col-md-3 col-md-offset-1">
						<a href="#" target="_blank">
							<img class="download-img" src="geoparking/images/tiendas/windows_phone.png"/>
						</a>
					</div>
					<div class="col-md-3 col-md-offset-1">
						<a href="#" target="_blank">
							<img class="download-img" src="geoparking/images/tiendas/app_store.png"/>
						</a>
					</div>					
			</div>
		</section>
		<!-- End Special features -->	

		<!-- Our Team -->	
		<section class="cd-section cd-container" id="our-team">
			<div class="container">
				<h1 class="page-header text-center">Los creadores</h1>
				<div id="descripcion-team" class="jumbotron">
					<span>
						Somos un equipo de estudiantes de ingeniería en sistemas de información de la Universidad Tecnológica Nacional - Facultad Regional Córdoba.
					</span>
				</div>
				<div class="col-md-2 text-center" style="margin:15px !important;">

					<div class="profile-wrap">
						<img src="geoparking/images/creadores/leo.jpg" alt="profile" />
						<ul>
							<li>
								<a href="#" target="_blank"><i class="fa fa-facebook"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-twitter"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-linkedin"></i></a>
							</li>							
						</ul>
					</div>
					<p class="profile-description ">Leo Romero</p>
					<p class="profile-description italic">Backend developer</p>
					<%--<p class="profile-level italic"><span class="blue">Ninja</span></p>--%>

				</div>	<!-- Leo -->			

				<div class="col-md-2 text-center" style="margin:15px !important;">					
					<div class="profile-wrap">
						<img src="geoparking/images/creadores/eze.jpg" alt="profile" />
						<ul>
							<li>
								<a href="#" target="_blank"><i class="fa fa-facebook"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-twitter"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-linkedin"></i></a>
							</li>						
						</ul>
					</div>
					<p class="profile-description">Eze Bär Coch</p>
					<p class="profile-description italic">UI/UX & Mobile Developer</p>
					<%--<p class="profile-level italic"><span class="white">Afilao</span></p>--%>

				</div><!-- Eze -->


				<div class="col-md-2 text-center" style="margin:15px !important;">			
					<div class="profile-wrap">
						<img src="geoparking/images/creadores/lucas.jpg" alt="profile" />
						<ul>
							<li>
								<a href="#" target="_blank"><i class="fa fa-facebook"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-twitter"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-linkedin"></i></a>
							</li>							
						</ul>
					</div>
					<p class="profile-description ">Lucas Toneatto</p>
					<p class="profile-description italic">Backend developer</p>
					<%--<p class="profile-level italic"><span class="orange">Malambero</span></p>--%>
				</div><!-- Lucas -->
				<div class="col-md-2 text-center" style="margin:15px !important;">				
					<div class="profile-wrap">
						<img src="geoparking/images/creadores/iraki2.jpg" alt="profile" />
						<ul>
							<li>
								<a href="#" target="_blank"><i class="fa fa-facebook"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-twitter"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-linkedin"></i></a>
							</li>							
						</ul>
					</div>
					<p class="profile-description">Marcos Barrera</p>
					<p class="profile-description italic">Javascript Developer</p>
					<%--<p class="profile-level italic"><span class="green">Iraki</span></p>			--%>	
				</div><!-- Irak -->
				<div class="col-md-2 text-center" style="margin:15px !important;">					
					<div class="profile-wrap">
						<img src="geoparking/images/creadores/nacho.jpg" alt="profile" />
						<ul>
							<li>
								<a href="#" target="_blank"><i class="fa fa-facebook"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-twitter"></i></a>
							</li>
							<li>
								<a href="#" target="_blank"><i class="fa fa-linkedin"></i></a>
							</li>							
						</ul>
					</div>
					<p class="profile-description">Nacho Frigerio</p>
					<p class="profile-description italic">Mobile Developer</p>
					<%--<p class="profile-level italic"><span class="yellow">Afilao</span></p>--%>
				</div><!-- Nacho -->
			</div>
		</section><!--Team  -->

		<!-- Stats -->	
		<section class="cd-section cd-container" id="wrap-stats">
			<div class="container text-center stats">
				<h1 class="page-header">Algunos números...</h1>
				<div class="col-md-4">
					<div class="chart1" data-percent="85">
						<span class="percent"></span>
						<p class="italic">Usuarios que probaron esta app, la utilizan a diario.</p>
					</div>
					<p class="stat-quote ">Referencia de la Ciudad de Córdoba</p>
				</div>
				<div class="col-md-4">
					<h2 class=" text-center">+ de 2000 descargas</h2>
					<div class="chart2" data-percent="75">
						<span class="percent"></span>
						<p class=" italic"></p>
					</div>
					<p class="stat-quote ">Son usuarios móviles (celulares, iphones, tablets).</p>
				</div>
				<div class="col-md-4">
					<div class="chart3" data-percent="65">
						<span class="percent"></span>
						<p class=" italic">De ahorro en tiempo, para buscar estacionamiento.</p>
					</div>
					<p class="stat-quote "> según usuarios de esta app.</p>
				</div>
			</div>
		</section>
		<!-- Testimonials -->		
		<section id="testimonials-wrap" class="cd-section cd-container">
			<div id="testimonials">				
				<!-- Testimonials carousel -->
				<div class="carousel-wrap">
					<ul id="testimonial-list" class="clearfix">
						<li>
							<p class="context">"La idea es genial, me ha servido mucho y me ha ahorrado muchas horas dando vuelta, buscando donde estacionar mi vehículo."</p>
							<p class="credits">Julia - Empleada administrativa<a href="#">, Ciudad de Córdoba.</a></p>
						</li>
						<li>
							<p class="context">"Realmente recomiendo esta aplicación, ya que mejora el desempeño del tráfico a nivel municipal."</p>
							<p class="credits">Oscar - Estudiante <a href="#">, Ciudad de Córdoba.</a></p>
						</li>
						<li>
							<p class="context">"Les recomiendo totalmente esta aplicación ya que es simple, fácil, rápida e intuitiva."</p>
							<p class="credits">Juan - Cajero<a href="#">, Ciudad de Córdoba.</a></p>
						</li>

					</ul>
				</div>
			</div>
		</section>	
		<!-- End Testimonials -->
		<section class="cd-section cd-container" id="contacto">
			<div class="container">
				<h1 class="page-header text-center">Estemos en contacto!</h1>
				<div id="mensaje" class="hidden col-md-6">
					<div class="jumbotron">
						<i id="check" class="fa fa-check"></i>
						<i id="loading" class="fa fa-spinner fa-spin"></i>
						<div id="textoMensaje">&nbsp;&nbsp;</div>
					</div>
				</div>
				<div class="col-md-6" id="formulario">
					<form method="POST" action="">
						<div class="form-group">
							<input required type="text" id="txtNombre" class="input-lg form-control" placeholder="Su nombre">
						</div>
						<div class="form-group">
							<input required type="email" id="txtEmail" class="input-lg form-control" placeholder="Su email">
						</div>
						<div class="form-group">
							<textarea required id="txtMensaje" rows="5" class="input-lg form-control" placeholder="Mensaje"></textarea>
						</div>
						<div class="form-group">
							<input onClick="enviarEmail()" type="button" class="btn btn-block btn-lg btn-success" value="Enviar">
						</div>
					</form>
				</div>
				<div class="col-md-6">
					<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d13619.157964385991!2d-64.19522719212648!3d-31.419925479089866!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1ses-419!2sar!4v1424115628655" width="530" height="320" frameborder="1" style="border:solid 1px #000"></iframe>
				</div>
			</div>
		</section>


		<a href="#" id="scrollToTop" data-toggle="tooltip" data-placement="top" title="Subir!"><i class="fa fa-caret-up"></i></a>
</div> <!-- .cd-main-content -->

<!-- footer  -->
<div id="footer" class="footer">		


	<div class="container rights">

		<!-- Copyrights -->
		<div class="col-sm-12 col-md-6 text-left">
			<p class="capitalize">&copy;&nbsp; GeoParking 2015.</p>
		</div>

		<!-- Social links -->
		<div class="col-sm-12 col-md-6 text-right social">
			<a href="#" target="blank"><i class="fa fa-facebook"></i></a>
			<a href="#" target="blank"><i class="fa fa-twitter"></i></a>						
		</div>
	</div>
</div>

</div><!-- container-->

<!-- JS Files Placed at the end of the document so the pages load faster -->
<script src="geoparking/assets/js/jquery.min.js"></script>
<script src="geoparking/assets/js/bootstrap.min.js"></script>
<script src="geoparking/assets/js/easypiechart.js"></script>
<script src="geoparking/assets/js/script.js"></script>
<script src="geoparking/assets/js/email.js"></script>

</body>
</html>


