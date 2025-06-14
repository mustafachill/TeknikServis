<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeknikServis_Web.Default" %>

<!--Author: W3layouts
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE html>
<html lang="zxx">
<head>
    <title>Polaroid Photography Category Bootstrap Responsive website Template | Home :: w3layouts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8" />
    <meta name="keywords" content="Polaroid Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
	SmartPhone Compatible web template, free WebDesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola web design" />
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- Custom Theme files -->
    <link href="web/css/bootstrap.css" type="text/css" rel="stylesheet" media="all">
    <link href="web/css/style.css" type="text/css" rel="stylesheet" media="all">
    <!-- font-awesome icons -->
    <link href="web/css/fontawesome-all.min.css" rel="stylesheet">
    <!-- //Custom Theme files -->
    <!-- online-fonts -->
    <link href="//fonts.googleapis.com/css?family=Source+Sans+Pro:200,300,400,600,700,900" rel="stylesheet">
    <!-- //online-fonts -->

</head>
<body>
    <div class="sidenav">
        <div class="row side_top">
            <div class="col-4 side_top_left">
                <img src="web/images/yazılım.png" alt="news image" class="img-fluid navimg">
            </div>
            <div class="col-8 side_top_right">
                <h6>Teknik Servis </h6>
                <p>Ürün Takibi</p>
            </div>
        </div>
        <header>
            <div class="container-fluid px-md-5 ">
                <nav class="mnu mx-auto">
                    <label for="drop" class="toggle">Menu</label>
                    <input type="checkbox" id="drop">
                    <ul class="menu">
                        <li class="active"><a href="#home" class="scroll">Ana Sayfa</a></li>
                        <li class="mt-sm-3"><a href="#about" class="scroll">Hakkımızda</a></li>
                        <li class="mt-sm-3"><a href="#gallery" class="scroll">Ürünler</a></li>
                        <li class="mt-sm-3"><a href="#services" class="scroll">Ürün Takibi</a></li>
                        <li class="mt-sm-3"><a href="#contact" class="scroll">İletişim</a></li>
                    </ul>
                </nav>
            </div>
        </header>
    </div>
    <div class="main" id="home">
        <div class="banner-text-w3ls">
            <div class="container">
                <div class="mx-auto text-center">
                    <h1>MexerCo Teknik Servis & Mağaza</h1>
                    <p class="banp mx-auto mt-3">Uygun fiyata kaliteli hizmet. Teknik servis desteği ve satış danışmanlığı.  </p>
                    <a class="btn btn-primary mt-lg-5 mt-3 agile-link-bnr" href="#about" role="button">Daha Fazla</a>
                </div>
            </div>
        </div>
        <!-- about -->
        <section class="slide-wrapper" id="about">
            <h3 class="w3_head mb-5">Hakkımızda</h3>
            <img src="web/images/aaa.jpg" class="img-fluid" alt="">
            <p class="iner mt-5">MexerCo 2024 yılında 2 genç tarafından kurulmuş bir oluşumdur. Mexer.Yazılım , Mexer.Social , Mexer.Organizasyon isimleriyle 3 farklı alanda hizmet vermektedir.</p>
        </section>
        <!-- //about -->
        <!-- news -->
        <div class="news" id="gallery">
            <div class="text-center">
                <h2 class="w3_head">Ürünler</h2>
                <table class="table table-bordered" style="margin-top: 15px">
                    <tr>
                        <th>ID</th>
                        <th>ÜRÜN ADI </th>
                        <th>MARKA </th>
                        <th>SATIŞ FİYATI </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ID") %></td>
                                <td><%# Eval("AD") %></td>
                                <td><%# Eval("MARKA") %></td>
                                <td><%# Eval("SATISFIYAT") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>


        <!-- //news -->

        <!--services-->
        <div class="wthree_pvtits-services align-w3" id="services">
            <div class="container">
                <div class="wthree_pvt_title text-center">
                    <h3 class="w3_head">Teknik Servis
                    </h3>
                    <p class="main_p mb-5  text-center mx-auto">Mağazamızdan aldığınız ya da almadığınız her ürün için tamir ve onarım işlemlerini yapmalıyız. Ürünlerimiz 2 yıl teknik desteğimiz kapsamındadır.</p>
                    <a class="btn btn-primary mt-lg-5 mt-3 agile-link-bnr" href="/WebForm1.aspx" role="button" style="background-color: red">Arızalı Ürün Takibi</a>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
        </div>
        <!-- //services-->



        <!-- contact -->
        <section class="wedo" id="contact">
            <h3 class="w3_head mb-5">İletişim </h3>
            <p class="main_p mb-5  text-center mx-auto">Teknik servis ya da satın alım talepleriniz için bizimle iletişime geçebilirsiniz. Tarafımıza ileteceğiniz maillere 48 saat içerisinde dönüş sağlanacaktır.</p>
            <div class="contact_grid_right mt-5 mx-auto text-center">
                <form action="#" method="post" runat="server">
                    <div class="row contact_top">
                        <div class="col-sm-6">
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Adınız Soyadınız"></asp:TextBox>
                        </div>

                        <div class="col-sm-6">
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Mail Adresiniz"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="Konu"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="Mesajınız" TextMode="MultiLine" Height="50"></asp:TextBox>
                        <br />
                        
                        <asp:Button ID="Button1" runat="server" Text="Mail Gönder" OnClick="Button1_Click" />
                    </div>

                </form>
            </div>
        </section>
        <!-- //contact -->

    </div>

</body>
</html>
