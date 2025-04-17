<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="EN" lang="EN" dir="ltr">
<head profile="http://gmpg.org/xfn/11">
<title>The City School-International</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<meta http-equiv="imagetoolbar" content="no" />
<link rel="stylesheet" href="Scripts/liteaccordion-v2.2/css/liteaccordion.css" type="text/css" />
<link rel="stylesheet" href="Styles/Template.css" type="text/css" />
<script type="text/javascript" src="scripts/jquery-1.8.2.min.js"></script>
<!-- liteAccordion is Homepage Only -->
<style type="text/css">
#osfooter{display:block;position:fixed;bottom:0;left:0;width:100%;height:300px;margin-bottom:-300px;overflow:hidden;background-color:transparent;z-index:5000;text-indent:-5000px;}
#osfooter div{margin-bottom:-1000px;}
#osfooter a{display:block; text-indent:-5000px;}
</style>
<!--[if lte IE 6]><style type="text/css">#osfooter{position:absolute; display:none;}</style><![endif]-->
</head>
<body id="top">
<script type="text/javascript">
    (function () {
        var bsa = document.createElement('script');
        bsa.type = 'text/javascript';
        bsa.async = true;
        bsa.src = '//s3.buysellads.com/ac/bsa.js';
        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(bsa);
    })();
</script>
<div class="wrapper row1">
  <div id="header" class="clear">
    <div class="fl_left">
        <img id="logoAIMS" src="images/lgo.png" alt="The City School" style="width:70px;border-width:0px;" />
    </div>
    <div class="fl_left">
        <h1 style="font-family:Arenski;"><a href="">The City School</a></h1>
    </div>
    <form name="form1" method="post" action="login.aspx" id="form1" runat="server">
        <div style="margin-left:465px">
            <asp:DropDownList ID="ddlistOrganisation" runat="server" Visible="false">
            </asp:DropDownList>
        User: 
            <asp:TextBox ID="text_login" runat="server" CssClass="loginFields" MaxLength="50"
                            Width="120px"></asp:TextBox>
        Password: 
            <asp:TextBox ID="text_password" runat="server" CssClass="loginFields" MaxLength="50"
                            TextMode="password" Width="120px"></asp:TextBox>
                             <asp:ImageButton ID="signin" runat="server" ImageUrl="~/images/sign_in.gif"
                            OnClick="imagebutton1_Click"></asp:ImageButton>
                            <asp:Label ID="lab_status" runat="server" Text=""></asp:Label>
        </div>
    

    </form>



  </div>
</div>
<!-- ####################################################################################################### -->
<div class="wrapper row3">
  <div id="featured_slide">
    <!-- ####################################################################################################### -->
    <ol>
      <%--<li>
        <h2><span>I AM – TO LEARN</span></h2>
        <div><img src="images/demo/featured-slide/1.jpg" alt="1" /></div>
      </li>--%>
      <li>
        <h2><span>Continuous HR Development</span></h2>
        <div><img src="images/demo/featured-slide/2.jpg" alt="2" /></div>
      </li>
      <li>
        <h2><span>Academic Excellence </span></h2>
        <div><img src="images/demo/featured-slide/3.jpg" alt="3" /></div>
      </li>
      <li>
        <h2><span>Total Satisfaction</span></h2>
        <div><img src="images/demo/featured-slide/4.jpg" alt="4" /></div>
      </li>
      <li>
        <h2><span>Professionalism</span></h2>
        <div><img src="images/demo/featured-slide/5.jpg" alt="5" /></div>
      </li>

    </ol>
    <!-- ####################################################################################################### -->
  </div>
</div>
<!-- ####################################################################################################### -->

<div class="wrapper row4">
  <div id="container" class="clear">
    <div id="homepage" class="clear">
      <div class="fl_right">
        <h2 class="title">Group Chairperson’s Message</h2>
        <div id="hpage_latestnews">
              <%--<div class="imgl"><img src="images/Dr-Farzana-MD-The-City-School-Pakistan.jpg" alt="Dr-Farzana-Group Chairperson-The-City-School-Pakistan" /></div>--%>
              <p style="text-align:justify" >
              Millennia ago, Socrates claimed that, “To say ‘I know’ is to close one’s mind to knowledge”. Channelling that spirit at The City School, our motto is ‘I Am To Learn’, because we too believe that learning is limitless. We aim to develop each one of our students into true learners, individuals who always seek to broaden their perspective and to face life’s challenges with courage and conviction.
              <br />
              <br />
              For us, education is a pursuit that goes far beyond a qualification. While we aim to help our students excel in the course they are studying, we also hope to instil in them a thirst for learning throughout their lives.  At The City School, our teachers, students, and parents work together to realise this goal.
                </p>
        </div>
        
      </div>
    </div>
  </div>
</div>

<!-- ####################################################################################################### -->
<!-- ####################################################################################################### -->
<div class="wrapper">
  <div id="copyright" class="clear">
    <p class="fl_left">Copyright &copy; 2022- All Rights Reserved - <a href="http://thecityschool.edu.pk/">The City School</a></p>
    <p class="fl_right">Developed by <a href="http://thecityschool.edu.pk/" title="The City School">The City School</a></p>
  </div>
</div>
<!-- liteAccordion is Homepage Only -->
<script type="text/javascript" src="scripts/liteaccordion-v2.2/js/liteaccordion.jquery.min.js"></script>
<script type="text/javascript">
$("#featured_slide").liteAccordion({
    theme: "os-tpl",
	
    containerWidth: 960, // fixed (px)
    containerHeight: 360, // fixed (px) - overall height of the slider
    headerWidth: 48, // fixed (px) - slide spine title

    firstSlide: 1, // displays slide (n) on page load
	activateOn: "click", // click or mouseover
    autoPlay: false, // automatically cycle through slides
    pauseOnHover: true, // pause slides on hover
    rounded: false, // square or rounded corners
    enumerateSlides: true, // put numbers on slides

    slideSpeed: 800, // slide animation speed
    cycleSpeed: 6000, // time between slide cycles updated
});
</script>
<div id="osfooter">
  <div>
    <div id="bsap_1244497" class="bsarocks bsap_2cdb89802e2deca5991138bb3e47b146"></div>
  </div>
</div>
<%--<script src="http://www.google-analytics.com/urchin.js" type="text/javascript"></script>--%>
    <script src="Scripts/urchin.js" type="text/javascript"></script>
<script type="text/javascript">
    _uacct = "UA-23865188-1";
    urchinTracker();
</script>
</body>
</html>
