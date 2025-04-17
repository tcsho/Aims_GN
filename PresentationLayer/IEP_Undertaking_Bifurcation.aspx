<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="IEP_Undertaking_Bifurcation.aspx.cs" Inherits="PresentationLayer_TCS_IEP_Undertaking_Bifurcation" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
         <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Bifurcation Student"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
                <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center">
<%--     <div class="button  btn btn-primary b1 printbtn ">
                <i class="fa fa-print" data-toggle="tooltip" data-placement="bottom" title="Print" ></i> Print

            </div>--%>
            <asp:Button ID="btnSave" runat="server" Text="Print and Send Email" OnClick="btnSave_Click" CssClass="button  btn btn-primary"  OnClientClick="printr(this)"/><!--OnClientClick="printr(this)-->
        </div>
                       <asp:Label ID="lblCenter_Id" runat="server" CssClass="bi_visibility"></asp:Label><asp:Label ID="lblStudent_Id" runat="server" CssClass="bi_visibility"></asp:Label><asp:Label ID="lblSession_Id" runat="server" CssClass="bi_visibility"></asp:Label><asp:Label ID="lblClass_Id" runat="server" CssClass="bi_visibility"></asp:Label><asp:Label ID="lblfatheremail" runat="server" CssClass="bi_visibility"></asp:Label>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center" style="padding:10px;">
              
          <%--   <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                 <div class="form-group">
                      <label>Class*:</label>
                                      <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged">
                         
                                        </asp:DropDownList>
                      </div>
         </div>--%>
             <%--   <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                    <label>Term</label>
                

                    <asp:DropDownList ID="BiTerm" runat="server" CssClass="dropdownlist  form-control">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="1">First Term</asp:ListItem>
                        <asp:ListItem Value="2">Second Term</asp:ListItem>
                       <asp:ListItem Value="3">Mock Term</asp:ListItem>
                    </asp:DropDownList>
             
                </div>--%>
              <%--  <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                     <div class="form-group">
                      <label >Student: </label>

                         <asp:DropDownList ID="ddlStudent" runat="server" CssClass="dropdownlist  form-control" 
                                                OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged" AutoPostBack="True"
                                                AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select Student"
                                                Display="Dynamic" ControlToValidate="ddlStudent"></asp:RequiredFieldValidator>
                        </div>
                </div>--%>
            </div>

            <!--undertaking form-->
        
                            <div class="PrintArea area1 all demo" id="Retain">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 Biletter_main" id="Biletter_main">
                          <!-------------------tab 2--------------------->

                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="row rowdisplayflex headerwithlogo">
           <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass">

                        </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">
                  
                       <h2 class="schoolname">The City School</h2>
                        <%--<span class="bi_lettersubheading" id="bi_lettersubheading">Class 8 Bifurcation Letter</span>--%>
                      <asp:Label runat="server" ID="bi_lettersubheading" CssClass="bi_lettersubheading"></asp:Label>
                      </div>
                      <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-right schoollogo">
                      <img src="Component_Marks/ReportCard/images/newlogo.png" />
                       </div>
                       </div>

                      </div>

                                <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12">
                                    <p class="bifirstpra">I, as a parent/guardian of <asp:Textbox ID="txt_Student_Name1" CssClass="bi_label bi_label_student text-center" runat="server" Enabled="false"></asp:Textbox> studying in <asp:Label runat="server" ID="bi_classchange" CssClass="bi_classchange fontsze"></asp:Label>Section <asp:TextBox ID="txt_Student_Section" CssClass="bi_label bi_labelsection" runat="server" Enabled="false"></asp:TextBox>
confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to apply the appropriate consequences stated:</p>

                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    
                                    <ul class="bi_bullet_list" runat="server" id="ul_List">
                                    <li>1) That the school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</li>
<li>2) However, at my insistence, the school has provisionally allowed my child to sit in Class 8 and take final examinations for the O level stream.</li>
<li>3) Accept the responsibility that my child must pass the Class 8 Annual examinations with the minimum required 
attainment levels. Failing to meet the minimum requirements may result in my child being privatized at the time of 
final Cambridge exams.</li>
<li>4) If at any point I want my child to join Class 9M, I will take full responsibility for the missed taught course.</li>
<li>5) I understand that I will also be responsible to register my child with the relevant Matric Board paying an 
additional fee, if applicable.</li>
                                        </ul>
                                </div>
                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <hr class="remark_line hide"/>
                         </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 rmarkheading text-center">
                                    <span class="hide">Parent’s Remarks</span>
                                </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 parentremarkmain" class="hide">
<%--                               <p style="border-bottom: 1px solid #000;">I, <input type="text" class="bi_label bi_label_father" disabled="true"/> father/mother/guardian of <input type="text" class="bi_label"  disabled="true"/> Class 8</p>--%>
                        <%--     <p><input type="text" class="bi_label" style="width:100%" disabled="true"/></p>
                            <p><input type="text" class="bi_label" style="width:100%" disabled="true"/></p>
                            <p><input type="text" class="bi_label" style="width:100%" disabled="true"/></p>--%>
                            <p  class="parentremark hide"><span>I,</span> <input type="text" class="bi_label bi_label_father" disabled="true"/><span>father/mother/guardian of </span><input type="text" class="bi_label"  disabled="true"/><span id="spn_class" runat="server">Class 8</span></p>
                            <%--<p ></p>
                            <p ></p>
                            <p ></p>--%>
                         </div>


                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 signdivmain">
                                 <%-- <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 signdiv" >
                                                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 signdiv1">
                                                    <label>Signature:</label>
                                                     <label>(Parent / Guardian)</label>
                                                 </div>
                                      <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 signdiv2">
                                          <asp:TextBox type="text" id="txtfathersign" runat="server" class="bi_label signnamess" style="width:100%" disabled="true"/>
                                      </div>
                                     
                                 </div>  
                                   <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 signdiv">
                                                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 signdiv1">
                                                    <label>Signature:</label>
                                                     <label>(School Head)</label>
                                                 </div>
                                      <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 signdiv2">
                                            <asp:TextBox type="text" id="txtheadname" runat="server" class="bi_label signnamess" style="width:100%" disabled="true"/>
                                        
                                      </div>
                                     
                                 </div>--%> 
                                 </div>
                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                       <label runat="server" visible="false" id="lblrcv">This undertaking is received from parent/guardian's email address, in response to the email sent by the school on </label>
                                      <%-- <asp:TextBox type="text" id="txtdate" runat="server" class="" style="width: auto;background: none;border: none;font-size: 13px;" disabled="true"/>--%>
                                  </div>
				</div>
          </div>
            <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center" style="padding:10px;">
        <%--    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />--%>
                </div>
 
            <!--for print-->
              <div style="border: solid 2px #999fff; float: left; margin-left: 20px;" class="SettingsBox">
        <div style="width: 400px; padding: 20px;">
            <div style="padding: 0 10px 10px;" class="buttonBar">
                <div class="button b1">Print</div>
                <div class="toggleDialog">open dialog</div>
            </div>

            <div style="font-weight: bold; border-top: solid 1px #999fff; padding-top: 10px;">Settings</div>
            <table>
                <tbody>
                    <tr>
                        <td><input value="popup" name="mode" id="popup" checked="" type="radio"> Popup</td>
                    </tr>
                    <tr>
                        <td style="padding-left: 20px;"><input value="popup" name="popup" id="closePop" type="checkbox"> Close popup</td>
                    </tr>
                    <tr>
                        <td><input value="iframe" name="mode" id="iFrame" type="radio"> IFrame</td>
                    </tr>
                    <tr>
                        <td>Extra css: <input type="text" name="extraCss" size="50" /></td>
                    </tr>
                    <tr>
                        <td>
                            <div class="settingName">Print area:</div>
                            <div class="settingVals">
                                <input type="checkbox" class="selPA" value="area1" checked /> Area 1<br>
                                <input type="checkbox" class="selPA" value="area2" checked /> Area 2<br>
                                <input type="checkbox" class="selPA" value="area3" checked /> Area 3<br>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="settingName">Retain Attributes:</div>
                            <div class="settingVals">
                                <input type="checkbox" checked name="retainCss" id="retainCss" class="chkAttr" value="class" /> Class
                                <br>
                                <input type="checkbox" checked name="retainId" id="retainId" class="chkAttr" value="id" /> ID
                                <br>
                                <input type="checkbox" checked name="retainStyle" id="retainId" class="chkAttr" value="style" /> Style
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="padding: 3px; border: solid 1px #ddd;">
                                Add to head :
                                <input type="checkbox" checked name="addElements" id="addElements" class="chkAttr" />
                                <pre>&lt;meta charset="utf-8" /&gt;<br>&lt;http-equiv="X-UA-Compatible" content="IE=edge"/&gt;</pre>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>



        <footer>okss</footer>
    </div>
            <!--for Print-->
            <!--undertaking form-->
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%" Width="100%" />

            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
<style>

    .fontsze {
    font-size:14px !important;
    }
    @font-face {
  font-family: signfont;
/*  src: url(../Styles/iep_dashboardfile/Handitype.ttf);*/
/*  src: url(../Styles/iep_dashboardfile/Autograph.ttf);*/
/*    src: url(../Styles/iep_dashboardfile/TheExcited.ttf);*/
     src: url(../Styles/iep_dashboardfile/CreattionDemo.otf);
/*    src: url(../Styles/iep_dashboardfile/RhythemSignature.ttf);*/
}

 

.signnamess {
  font-family: signfont;
    font-size: 31px;
    text-transform: lowercase;
}

.Biletter_main .parentremarkmain p {
    
    border-bottom: 1px solid #000 !important;
}
</style>

</asp:Content>




