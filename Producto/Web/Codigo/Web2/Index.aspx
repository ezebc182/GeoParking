<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />--%>
		<%--<link rel="shortcut icon" href="images/fav.png" />	--%>
		<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
		<script src="js/index/jquery.min.js"></script>
		 <!---- start-smoth-scrolling---->
		<script type="text/javascript" src="js/index/move-top.js"></script>
		<script type="text/javascript" src="js/index/easing.js"></script>
		<script type="text/javascript">
		    jQuery(document).ready(function ($) {
		        $(".scroll").click(function (event) {
		            event.preventDefault();
		            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
		        });
		    });
		</script>
		 <!-- Custom Theme files -->
		<link href="css/index/style.css" rel='stylesheet' type='text/css' />
   		 <!-- Custom Theme files -->
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<script type="application/x-javascript"> 
            addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		</script>
		<!----webFonts---->
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,800,700' rel='stylesheet' type='text/css'>
		<!----//webfonts---->
		<!----start-top-nav-script---->
		<script>
		    $(function () {
		        var pull = $('#pull');
		        menu = $('nav ul');
		        menuHeight = menu.height();
		        $(pull).on('click', function (e) {
		            e.preventDefault();
		            menu.slideToggle();
		        });
		        $(window).resize(function () {
		            var w = $(window).width();
		            if (w > 320 && menu.is(':hidden')) {
		                menu.removeAttr('style');
		            }
		        });
		    });
		</script>
		<!----//End-top-nav-script---->

    <link href="css/index.css" rel="stylesheet" />
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="intro">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <h1 class="brand-heading" style="text-shadow: 4px 4px 13px rgb(30, 28, 28);"><span style="color: red;">Geo</span>Parking</h1>
                    <p style="text-shadow: 4px 4px 13px rgba(30, 28, 28 ,1);" class="intro-text">Estacioná de manera fácil, rápida y efectiva.</p>
                    <div class="input-group col-lg-4 col-lg-offset-4">
                        <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg autosuggest" runat="server"
                            ClientIDMode="Static" placeholder="Ingresá tu ciudad" autofocus></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:Button ID="btnBuscar" CssClass="btn-primary btn btn-lg" runat="server" Text="Buscar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <br />
    <br />
    <br />
    
    <script src="js/index/responsiveslides.min.js"></script>

    <!--features-->
			<div id="fea" class="features">
				<div class="container">
					<div class="section-head text-center">
						<h3><span class="frist"> </span>AMAZING FEATURES<span class="second"> </span></h3>
						<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta.</p>
					</div>
					<!----features-grids-->
					<div class="features-grids">
						<div class="col-md-4 features-grid">
							<div class="features-grid-info">
								<div class="col-md-2 features-icon">
									<span class="f-icon0"> </span>
								</div>
								<div class="col-md-10 features-info">
									<h4>Accusan timar</h4>
									<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.</p>
								</div>
								<div class="clearfix"> </div>
							</div>
							<div class="features-grid-info">
								<div class="col-md-2 features-icon">
									<span class="f-icon1"> </span>
								</div>
								<div class="col-md-10 features-info">
									<h4>Accusan timar</h4>
									<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.</p>
								</div>
								<div class="clearfix"> </div>
							</div>
							<div class="features-grid-info">
								<div class="col-md-2 features-icon">
									<span class="f-icon2"> </span>
								</div>
								<div class="col-md-10 features-info">
									<h4>Accusan timar</h4>
									<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.</p>
								</div>
								<div class="clearfix"> </div>
							</div>
							
						</div><!---end-features-grid---->
						<div class="col-md-4 features-grid">
							<div class="big-divice">
								<img src="img/index/divice.png" title="features-demo" />
							</div>
						</div><!---end-features-grid---->
						<div class="col-md-4 features-grid">
							<div class="features-grid-info">
								<div class="col-md-2 features-icon1">
									<span class="f-icon3"> </span>
								</div>
								<div class="col-md-10 features-info">
									<h4>Accusan timar</h4>
									<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.</p>
								</div>
								<div class="clearfix"> </div>
							</div>
							<div class="features-grid-info">
								<div class="col-md-2 features-icon1">
									<span class="f-icon4"> </span>
								</div>
								<div class="col-md-10 features-info">
									<h4>Accusan timar</h4>
									<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.</p>
								</div>
								<div class="clearfix"> </div>
							</div>
							<div class="features-grid-info">
								<div class="col-md-2 features-icon1">
									<span class="f-icon5"> </span>
								</div>
								<div class="col-md-10 features-info">
									<h4>Accusan timar</h4>
									<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.</p>
								</div>
								<div class="clearfix"> </div>
							</div>
							
						</div><!---end-features-grid---->
						<div class="clearfix"> </div>
					</div>
				</div>
					<!----//features-grids----->
					<!----//features----->
					<!----screen-shot-gallery---->
					<div id="gallery" class="screen-shot-gallery">
						<div class="container">
							<div class="section-head text-center">
								<h3><span class="frist"> </span>SCREENSHOTS GALLERY<span class="second"> </span></h3>
								<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta.</p>
							</div>
						</div>
						<!----sreen-gallery-cursual---->
						<%--aqui iria una galeria--%>
				    </div>
				<!--//screen-shot-gallery---->
				<!---- show-reel ---->
				    <div class="show-reel text-center">
					    <div class="container">
						    <%--aqui iria el video--%>
					    </div>					
					</div>
				
				<!---- //show-reel ---->
				<!----team---->
				<div id="about" class="team">
					<div class="container">
						<div class="section-head text-center">
							<h3><span class="frist"> </span>PEOPLE BEHIND THE APP<span class="second"> </span></h3>
							<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta.</p>
						</div>
					</div>
					<!----team-members---->
					<div class="team-members">
						<div class="container">
							<div class="col-md-3 team-member">
								<div class="team-member-info">
									<img class="member-pic" src="img/index/team-member4.jpg" title="name" />
									<h5><a href="#">Jonh Doe eh</a></h5>
									<span>Lead Designer</span>
									<label class="team-member-caption text-center">
										<p>sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem.</p>
										<ul>
											<li><a class="t-twitter" href="#"><span> </span></a></li>
											<li><a class="t-facebook" href="#"><span> </span></a></li>
											<li><a class="t-googleplus" href="#"><span> </span></a></li>
											<div class="clearfix"> </div>
										</ul>
									</label>
								</div>
							</div><!--- end-team-member -->
							<div class="col-md-3 team-member">
								<div class="team-member-info">
									<img class="member-pic" src="img/index/team-member1.jpg" title="name" />
									<h5><a href="#">Amanda Fenrnicas</a></h5>
									<span>Lead Developer</span>
									<label class="team-member-caption text-center">
										<p>sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem.</p>
										<ul>
											<li><a class="t-twitter" href="#"><span> </span></a></li>
											<li><a class="t-facebook" href="#"><span> </span></a></li>
											<li><a class="t-googleplus" href="#"><span> </span></a></li>
											<div class="clearfix"> </div>
										</ul>
									</label>
								</div>
							</div><!--- end-team-member -->
							<div class="col-md-3 team-member">
								<div class="team-member-info">
									<img class="member-pic" src="img/index/team-member2.jpg" title="name" />
									<h5><a href="#">Hamberg Rodny</a></h5>
									<span>Artist</span>
									<label class="team-member-caption text-center">
										<p>sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem.</p>
										<ul>
											<li><a class="t-twitter" href="#"><span> </span></a></li>
											<li><a class="t-facebook" href="#"><span> </span></a></li>
											<li><a class="t-googleplus" href="#"><span> </span></a></li>
											<div class="clearfix"> </div>
										</ul>
									</label>
								</div>
							</div><!--- end-team-member -->
							<div class="col-md-3 team-member">
								<div class="team-member-info">
									<img class="member-pic" src="img/index/team-member3.jpg" title="name" />
									<h5><a href="#">Jessica Leonardo</a></h5>
									<span>Photographer</span>
									<label class="team-member-caption text-center">
										<p>sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem.</p>
										<ul>
											<li><a class="t-twitter" href="#"><span> </span></a></li>
											<li><a class="t-facebook" href="#"><span> </span></a></li>
											<li><a class="t-googleplus" href="#"><span> </span></a></li>
											<div class="clearfix"> </div>
										</ul>
									</label>
								</div>
							</div><!--- end-team-member -->
							<div class="clearfix"> </div>
						</div>
							<div class="clearfix"> </div>
					<!--//team-members---->
					</div>
				</div>
				<!----//team---->
				<div class="clearfix"> </div>
				
			<!-----getintouch-->
			<div id="contact" class="getintouch">
				<div class="container">
					<div class="section-head text-center">
						<h3><span class="frist"> </span>GET IN TOUCH<span class="second"> </span></h3>
						<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta.</p>
					</div>
					<!---->
					<div class="col-md-9 getintouch-left">
						<div class="contact-form col-md-10">
							<h3>Say hello!</h3>
							<form>
								<input type="text" placeholder="Name" required />
								<input type="text"  placeholder="Email" required />
								<textarea placeholder="Message" required /> </textarea>
								<input type="submit" value="Send message" />
							</form>
						</div>
						<ul class="footer-social-icons col-md-2 text-center">
							<li><a class="f-be" href="#"><span> </span></a></li>
							<li><a class="f-tw" href="#"><span> </span></a></li>
							<li><a class="f-db" href="#"><span> </span></a></li>
							<li><a class="f-ti" href="#"><span> </span></a></li>
							<li><a class="f-go" href="#"><span> </span></a></li>
							<div class="clearfix"> </div>
						</ul>
					</div>
					<div class="col-md-2 getintouch-left">
						<div class="footer-divice">
							<img src="img/index/divice-half.png" title="getintouch" />
						</div>
					</div>	
				</div>
			</div>
			<!---//getintouch----->
			<!-----footer-->
			<div class="footer">
				<div class="container">
					<div class="footer-grids">
						<div class="col-md-3 footer-grid about-info">
							<a href="#"><img src="img/index/logo.png" title="Umbrella" /></a>
							<p>eusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
						</div>
						<div class="col-md-3 footer-grid subscribe">
							<h3>Subscribe </h3>
							<form>
								<input type="text" placeholder="" required />
								<input type="submit" value="" />
							</form>
							<p>eusmod tempor incididunt ut labore et dolore magna aliqua. </p>
						</div>
						<div class="col-md-3 footer-grid explore">
							<h3>Explore</h3>
							<ul class="col-md-6">
								<li><a href="#">Envato</a></li>
								<li><a href="#">Themecurve</a></li>
								<li><a href="#">Kreativeshowcase</a></li>
								<li><a href="#">Freebiescurve</a></li>
							</ul>
							<ul class="col-md-6">
								<li><a href="#">Themeforest</a></li>
								<li><a href="#">Microsoft</a></li>
								<li><a href="#">Google</a></li>
								<li><a href="#">Yahoo</a></li>
							</ul>
							<div class="clearfix"> </div>
						</div>
						<div class="col-md-3 footer-grid copy-right">
							<p>Eusmod tempor incididunt ut labore et dolore magna aliqua. ut labore et dolore magna aliqua. </p>
							<p class="copy">Template by <a href="http://w3layouts.com/">w3layouts</a></p>
						</div>
						<div class="clearfix"> </div>
						<script type="text/javascript">
						    $(document).ready(function () {
						        /*
								var defaults = {
						  			containerID: 'toTop', // fading element id
									containerHoverID: 'toTopHover', // fading element hover id
									scrollSpeed: 1200,
									easingType: 'linear' 
						 		};
								*/

						        $().UItoTop({ easingType: 'easeOutQuart' });

						    });
						</script>
							<a href="#" id="toTop" style="display: block;"> <span id="toTopHover" style="opacity: 1;"> </span></a>
					</div>
				</div>
			</div>
			<!---//footer-->

</asp:Content>

