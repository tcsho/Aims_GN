

<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="IEP_Reports.aspx.cs" Inherits="PresentationLayer_IEP_Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
<%--    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            
        </Scripts>
    </cc1:ToolkitScriptManager>--%>
  <div class='overlay'></div>
<div id="exTab1" class="container">	
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 iep_printbtn">
       <div class="button  btn btn-primary b1 printbtn ">
                <i class="fa fa-print" data-toggle="tooltip" data-placement="bottom" title="Print" ></i> Print

            </div>
 
    <button type="button" class="ieppendingstudent btn btn-danger" style="float: right;">Pending Student</button>
    </div>
<ul  class="nav nav-pills classtab">
    <li class="active" data-id="8" data-value="12" data-title="iep8"><a href="#iep8" data-toggle="tab">IEP – Grade 8</a>
			</li>
		
			
			<li data-id="9" data-value="13" data-title="iep9"><a href="#iep9" data-toggle="tab">IEP – Grade 9</a>
			</li>
  		<li data-id="10" data-value="14" data-title="iep10" ><a href="#iep10" data-toggle="tab">IEP – Grade 10</a>
			</li>
    		<li data-id="11" data-value="15" data-title="iep11"><a href="#iep11" data-toggle="tab">IEP – Grade 11</a>
			</li>

    	<li  data-id="A2" data-value="20" data-title="iepasa">
        <a  href="#iepasa" data-toggle="tab">IEP Form AS-A2</a>
			</li>
		</ul>
    <input type="text" class="classnameofcurrent iephiddenfield" />
    <input type="text" class="classidofcurrent iephiddenfield" />
      <input type="text" class="studentinfoidofcurrent iephiddenfield" />
			<div class="tab-content clearfix">
                  	<div class="tab-pane active" id="iep8">
                      <div class="PrintArea area1 all demo IEP_Grade8" id="Retain">
          
                          <!-------------------tab 2--------------------->

                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="row rowdisplayflex headerwithlogo">
           <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass">

                        </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">
                  
                       <h2 class="schoolname">The City School</h2>
                        <h6>Academic Session 2020-21</h6>
                       <h5>Individual Educational Plan [IEP] – Grade 8 Students </h5>
                      </div>
                      <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-right schoollogo">
                      <img src="Component_Marks/ReportCard/images/logo.png" />
                       </div>
                       </div>

                      </div>
                               <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center tr_headingcolor">
                                     <p>Student Detail</p>
                               </div>
                        <table class="table table-bordered custom_table_styling ">
                     
                            <tr><td>Name</td><td class="nopadding_tds"><%--<input type="text" class="form-control name" />--%>
                                <select class="name form-control">
                        </select>
                                             </td><td>Roll No</td><td class="nopadding_tds"><input type="text" class="form-control rollno" disabled="disabled"/></td></tr>
                             <tr><td>Class</td><td class="nopadding_tds"><input type="text" class="form-control classval" disabled="disabled"/></td><td>Contact No</td><td class="nopadding_tds"><input type="text" class="form-control contactno" disabled="disabled"/></td></tr>
                            <tr><td>Email</td><td class="nopadding_tds"><input type="text" class="form-control emailaddr" disabled="disabled"/></td><td>Expected Graduation Year:</td><td class="nopadding_tds"><input type="text" class="form-control graduationyear" /></td></tr>
                                <tr><td>Career Goal & Major: </td>
                                    <td class="nopadding_tds">
                                    <table class="table table-bordered custom_table_styling"><tr><td >Plan A</td><td>Plan B</td></tr>
                               <tr><td class="nopadding_tds"><input type="text" class="form-control plan_a" /></td><td class="nopadding_tds"><input type="text" class="form-control plan_b" /></td></tr>
                                   
                                    </table>
                                         </td>
                                    <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td>3- Dream Universities:</td></tr>
                                         
                                   
                                    </table>
                                         </td>
                                    <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td class="nopadding_tds"><input type="text" class="form-control dreamuni_1" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_2" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_3" /></td></tr>
                     
                                   
                                    </table>
                                         </td>
                                


                                </tr>
                        </table>

                         <h4>Academic History</h4>
                          <div class="academicdatatable">
                           <table class="table table-bordered custom_table_styling academic_history academchange academictour">
                            <thead>
                                <tr><th>Serial #</th><th>Grade 7-Subjects</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                          



                                
                               </tbody>
                        </table>
                              </div>
                           <h4>Teacher Feedback</h4>
                          <div class="teacherfeedbacktable">
                      <%--     <table class="table table-bordered custom_table_styling">
                            <thead>
                                <tr><th>Key Area</th><th>English</th><th>Mathematics</th><th>Islamiyat</th><th>Geography</th><th>Science</th><th>Urdu</th><th>History</th> </tr>
                                       
                            </thead>
                               <tbody>
                                   



                                   <tr><td>Subject Strengths</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
                                    <tr><td>Subject areas to focus</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
                                    <tr><td>Academic Potential</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
                                    <tr><td>Suggested study hours</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
                                         <tr><td>Suggested study pattern</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
                               </tbody>
                        </table>--%>
                              </div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom pehlewala">
                            </div>
                          <h4>Personal Information</h4>
                     <p>Is there anything else you would like for someone writing a recommendation to know about you? (Hardships you 
                        have overcome, accomplishments you are particularly proud of etc.):</p>
                         <textarea class="form-control personal_info" rows="4"></textarea>
                          <h4>Personal Strengths</h4>
                     <ol class="personalstrength border_bottom_list">
                            <li><input type="text" class="form-control personalstrength_1" /></li>
                            <li><input type="text" class="form-control personalstrength_2" /></li>
                            <li><input type="text" class="form-control personalstrength_3" /></li>
                      </ol>

                                <h4>Qualities to Develop</h4>
                     <ol class="qualitydevelop border_bottom_list">
                            <li><input type="text" class="form-control qualitydevelop_1" /></li>
                            <li><input type="text" class="form-control qualitydevelop_2" /></li>
                            <li><input type="text" class="form-control qualitydevelop_3" /></li>
                      </ol>

                             <h4>Hobbies/Interests</h4>
                
                         <textarea class="form-control hobbies_interest" rows="4"></textarea>


                          
                    <h4>Study habits (hours/pattern):</h4> 
 
                    <ul><li>hours/ day</li></ul>

<h4>Activities Information:</h4>
                         <p>(Academic clubs, Sports, Extra Curriculars, Community-based Clubs)</p>
                           <table class="table table-bordered custom_table_styling activitiestable">
                            <thead>
                                <tr><th>Organization</th><th>Brief description</th><th>Dates participated</th> <th>Leadership Roles</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>


                         <h4>Community Service:</h4>
                         <p>Many colleges and scholarship programs emphasize community service. List ways in which you have given back to the community. Give dates, approximate hours you spent and what you did.</p>
                           <table class="table table-bordered custom_table_styling communitiestable">
                            <thead>
                                <tr><th>Organization/Location</th><th>Brief description of service provided</th><th>Dates participated</th> <th>Hours spent</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>

                          
                         
               

                         <p>Name two City School teachers who know you well and would speak highly of you:</p>
                         <ol class="nameofcity border_bottom_list">
                             <li><input class="form-control" /></li>
                              <li><input class="form-control" /></li>
                         </ol>

                         <h4>Questions for Parents:</h4>
                         <ol class="question_parent border_bottom_list">
                             <li><p>In your opinion, what are his/her strengths and weaknesses?</p><input class="form-control" /></li>
                              <li><p>How does he/she learn best?</p><input class="form-control" /></li>
                              <li><p>What are your long-term goals for him/her?</p><input class="form-control" /></li>
                         </ol>

                         <h4>Comments/Recommendations made by Counselor: </h4>
                
                         <textarea class="form-control comments_counsler" rows="4"></textarea>
                          <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 abovetxt">
                              <p>The above information is true and accurate to the best of my knowledge:</p>
                          </div>
                         <div class="row">
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control student_sign border_bottomtextbox"/><p class="text-center">Student’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control pri_sign border_bottomtextbox"/><p class="text-center">Principal’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control parent_sign border_bottomtextbox"/><p class="text-center">Parent’s signature</p></div> 
                                

                         </div>

                          <!-----------------TAB 2----------------------->
                           <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12">
                             <button type="button" class="btn btn-primary IEP_btn">Submit</button>
                         </div>

				</div>
                          
                    </div>
			
			
        <div class="tab-pane" id="iep9">
          <!--------------------------TAB 3----------------->

             <div class="PrintArea area2 all demo IEP_Grade9" id="Retain">
          
                        

                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="row rowdisplayflex headerwithlogo">
           <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass">

                        </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">
                  
                       <h2 class="schoolname">The City School</h2>
                        <h6>Academic Session 2020-21</h6>
                       <h5>Individual Educational Plan [IEP] – Grade 9 (O Levels/Matric) Students </h5>
                      </div>
                      <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-right schoollogo">
                      <img src="Component_Marks/ReportCard/images/logo.png" />
                       </div>
                       </div>

                      </div>
                               <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center tr_headingcolor">
                                     <p>Student Detail</p>
                               </div>
                        <table class="table table-bordered custom_table_styling">
                     
                            <tr><td>Name</td><td class="nopadding_tds"><%--<input type="text" class="form-control name" />--%>
                                      <select class="name form-control">
                        </select>

                                             </td><td>Roll No</td><td class="nopadding_tds"><input type="text" class="form-control rollno" disabled="disabled"/></td></tr>
                             <tr><td>Class</td><td class="nopadding_tds"><input type="text" class="form-control classval" disabled="disabled"/></td><td>Contact No</td><td class="nopadding_tds"><input type="text" class="form-control contactno" disabled="disabled"/></td></tr>
                            <tr><td>Email</td><td class="nopadding_tds"><input type="text" class="form-control emailaddr" disabled="disabled"/></td><td>Expected Graduation Year:</td><td class="nopadding_tds"><input type="text" class="form-control graduationyear" /></td></tr>
                                <tr><td>Career Goal & Major: </td>
                                    <td class="nopadding_tds">
                                    <table class="table table-bordered custom_table_styling"><tr><td >Plan A</td><td>Plan B</td></tr>
                               <tr><td class="nopadding_tds"><input type="text" class="form-control plan_a" /></td><td class="nopadding_tds"><input type="text" class="form-control plan_b" /></td></tr>
                                   
                                    </table>
                                         </td>
                                    <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td>3- Dream Universities:</td></tr>
                                   
                                    </table>
                                         </td>
                                    <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td class="nopadding_tds"><input type="text" class="form-control dreamuni_1" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_2" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_3" /></td></tr>
                                   
                                    </table>
                                         </td>
                                


                                </tr>
                        </table>

                         <h4>Academic History</h4>
                   <%--      <div class="academicdatatable">
                           <table class="table table-bordered custom_table_styling academic_history academchange">
                            <thead>
                                      <tr><th>Serial #</th><th>Grade 8-Subjects</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                          



                                
                               </tbody>
                        </table>
                              </div>--%>
                           <table class="table table-bordered custom_table_styling academic_history academictour">
                            <thead>
                             <tr><th>Serial #</th><th>Grade 8-Subjects</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                         



                                
                               </tbody>
                        </table>

                           <h4>Teacher Feedback</h4>
                         <div class="teacherfeedbacktable"></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom pehlewala">
                            </div>
                          <h4>Personal Information</h4>
                     <p>Is there anything else you would like for someone writing a recommendation to know about you? (Hardships you 
                        have overcome, accomplishments you are particularly proud of etc.):</p>
                         <textarea class="form-control personal_info" rows="4"></textarea>
                          <h4>Personal Strengths</h4>
                     <ol class="personalstrength border_bottom_list">
                            <li><input type="text" class="form-control personalstrength_1" /></li>
                            <li><input type="text" class="form-control personalstrength_2" /></li>
                            <li><input type="text" class="form-control personalstrength_3" /></li>
                      </ol>

                                <h4>Qualities to Develop</h4>
                     <ol class="qualitydevelop border_bottom_list">
                            <li><input type="text" class="form-control qualitydevelop_1" /></li>
                            <li><input type="text" class="form-control qualitydevelop_2" /></li>
                            <li><input type="text" class="form-control qualitydevelop_3" /></li>
                      </ol>

                             <h4>Hobbies/Interests</h4>
                
                         <textarea class="form-control hobbies_interest" rows="4"></textarea>


                          
                    <h4>Study habits (hours/pattern):</h4> 
 
                    <ul><li>hours/ day</li></ul>

<h4>Activities Information:</h4>
                         <p>(Academic clubs, Sports, Extra Curriculars, Community-based Clubs)</p>
                           <table class="table table-bordered custom_table_styling activitiestable">
                            <thead>
                                <tr><th>Organization</th><th>Brief description</th><th>Dates participated</th> <th>Leadership Roles</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>


                         <h4>Community Service:</h4>
                         <p>Many colleges and scholarship programs emphasize community service. List ways in which you have given back to the community. Give dates, approximate hours you spent and what you did.</p>
                           <table class="table table-bordered custom_table_styling communitiestable">
                            <thead>
                                <tr><th>Organization/Location</th><th>Brief description of service provided</th><th>Dates participated</th> <th>Hours spent</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>

                          
                         
               

                         <p>Name two City School teachers who know you well and would speak highly of you:</p>
                         <ol class="nameofcity border_bottom_list">
                             <li><input class="form-control" /></li>
                              <li><input class="form-control" /></li>
                         </ol>

                         <h4>Questions for Parents:</h4>
                         <ol class="question_parent border_bottom_list">
                             <li><p>In your opinion, what are his/her strengths and weaknesses?</p><input class="form-control" /></li>
                              <li><p>How does he/she learn best?</p><input class="form-control" /></li>
                              <li><p>What are your long-term goals for him/her?</p><input class="form-control" /></li>
                         </ol>

                         <h4>Comments/Recommendations made by Counselor: </h4>
                
                         <textarea class="form-control comments_counsler" rows="4"></textarea>
                          <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 abovetxt">
                              <p>The above information is true and accurate to the best of my knowledge:</p>
                          </div>
                         <div class="row">
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control student_sign border_bottomtextbox"/><p class="text-center">Student’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control pri_sign border_bottomtextbox"/><p class="text-center">Principal’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control parent_sign border_bottomtextbox"/><p class="text-center">Parent’s signature</p></div> 
                                

                         </div>

                           <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12">
                             <button type="button" class="btn btn-primary IEP_btn">Submit</button>
                         </div>


				</div>

            <!---------------------TAB 3------------------------>
				</div>
          <div class="tab-pane" id="iep10">
        <!--------------------------TAB 4----------------->

             <div class="PrintArea area3 all demo IEP_Grade10" id="Retain">
          
                        

                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="row rowdisplayflex headerwithlogo">
           <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass">

                        </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">
                  
                       <h2 class="schoolname">The City School</h2>
                        <h6>Academic Session 2020-21</h6>
                       <h5>Individual Educational Plan [IEP] – Grade 10 (O Levels/Matric) Students </h5>
                      </div>
                      <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-right schoollogo">
                      <img src="Component_Marks/ReportCard/images/logo.png" />
                       </div>
                       </div>

                      </div>
                               <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center tr_headingcolor">
                                     <p>Student Detail</p>
                               </div>
                        <table class="table table-bordered custom_table_styling">
                     
                            <tr><td>Name</td><td class="nopadding_tds"><%--<input type="text" class="form-control name" />--%>
                                               <select class="name form-control"></select>
                                             </td><td>Roll No</td><td class="nopadding_tds"><input type="text" class="form-control rollno" disabled="disabled"/></td></tr>
                             <tr><td>Class</td><td class="nopadding_tds"><input type="text" class="form-control classval" disabled="disabled"/></td><td>Contact No</td><td class="nopadding_tds"><input type="text" class="form-control contactno" disabled="disabled"/></td></tr>
                            <tr><td>Email</td><td class="nopadding_tds"><input type="text" class="form-control emailaddr" disabled="disabled"/></td><td>Expected Graduation Year:</td><td class="nopadding_tds"><input type="text" class="form-control graduationyear" /></td></tr>
                                <tr><td>Career Goal & Major: </td>
                                    <td class="nopadding_tds">
                                    <table class="table table-bordered custom_table_styling"><tr><td >Plan A</td><td>Plan B</td></tr>
                               <tr><td class="nopadding_tds"><input type="text" class="form-control plan_a" /></td><td class="nopadding_tds"><input type="text" class="form-control plan_b" /></td></tr>
                                   
                                    </table>
                                         </td>
                                   <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td>3- Dream Universities:</td></tr>
                                               <tr><td>3 Backup Universities:</td></tr>
                                   
                                    </table>
                                         </td>
                                    <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td class="nopadding_tds"><input type="text" class="form-control dreamuni_1" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_2" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_3" /></td></tr>
                                               <tr><td class="nopadding_tds"><input type="text" class="form-control backupuni_1" /></td><td class="nopadding_tds"><input type="text" class="form-control backupuni_2" /></td><td class="nopadding_tds"><input type="text" class="form-control backupuni_3" /></td></tr>
                                   
                                    </table>
                                         </td>
                                


                                </tr>
                        </table>

                         <h4>Academic History</h4>
                           <table class="table table-bordered custom_table_styling academic_history1 academchange academictour">
                            <thead>
                             <tr><th>Serial #</th><th>Grade 8-Subjects</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                                
                               </tbody>
                        </table>

                  <table class="table table-bordered custom_table_styling academic_history2 academchange">
                            <thead>
                             <tr><th>Serial #</th><th>Grade 9-Subjects</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                                
                               </tbody>
                        </table>

                <%--   <div class="academicdatatable">
                 
                              </div>--%>

                          <h4>Teacher Feedback</h4>
                         <div class="teacherfeedbacktable"></div>
                          <h4>Personal Information</h4>
                     <p>Is there anything else you would like for someone writing a recommendation to know about you? (Hardships you 
                        have overcome, accomplishments you are particularly proud of etc.):</p>
                           <textarea class="form-control personal_info" rows="4"></textarea>
                             <h4>Personal Strengths</h4>
                     <ol class="personalstrength border_bottom_list">
                            <li><input type="text" class="form-control personalstrength_1" /></li>
                            <li><input type="text" class="form-control personalstrength_2" /></li>
                            <li><input type="text" class="form-control personalstrength_3" /></li>
                      </ol>

                                <h4>Qualities to Develop</h4>
                     <ol class="qualitydevelop border_bottom_list">
                            <li><input type="text" class="form-control qualitydevelop_1" /></li>
                            <li><input type="text" class="form-control qualitydevelop_2" /></li>
                            <li><input type="text" class="form-control qualitydevelop_3" /></li>
                      </ol>

                             <h4>Hobbies/Interests</h4>
                
                         <textarea class="form-control hobbies_interest" rows="4"></textarea>


                          
                    <h4>Study habits (hours/pattern):</h4> 
 
                    <ul><li>hours/ day</li></ul>

<h4>Activities Information:</h4>
                         <p>(Academic clubs, Sports, Extra Curriculars, Community-based Clubs)</p>
                           <table class="table table-bordered custom_table_styling activitiestable">
                            <thead>
                                <tr><th>Organization</th><th>Brief description</th><th>Dates participated</th> <th>Leadership Roles</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>


                         <h4>Community Service:</h4>
                         <p>Many colleges and scholarship programs emphasize community service. List ways in which you have given back to the community. Give dates, approximate hours you spent and what you did.</p>
                           <table class="table table-bordered custom_table_styling communitiestable">
                            <thead>
                                <tr><th>Organization/Location</th><th>Brief description of service provided</th><th>Dates participated</th> <th>Hours spent</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>

                          
                         
               

                         
                         <p>Name two City School teachers who know you well and would speak highly of you:</p>
                         <ol class="nameofcity border_bottom_list">
                             <li><input class="form-control" /></li>
                              <li><input class="form-control" /></li>
                         </ol>

                         <h4>Questions for Parents:</h4>
                         <ol class="question_parent border_bottom_list">
                             <li><p>In your opinion, what are his/her strengths and weaknesses?</p><input class="form-control" /></li>
                              <li><p>How does he/she learn best?</p><input class="form-control" /></li>
                              <li><p>What are your long-term goals for him/her?</p><input class="form-control" /></li>
                         </ol>

                         <h4>Comments/Recommendations made by Counselor: </h4>
                
                         <textarea class="form-control comments_counsler" rows="4"></textarea>
                          <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 abovetxt">
                              <p>The above information is true and accurate to the best of my knowledge:</p>
                          </div>
                         <div class="row">
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control student_sign border_bottomtextbox"/><p class="text-center">Student’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control pri_sign border_bottomtextbox"/><p class="text-center">Principal’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control parent_sign border_bottomtextbox"/><p class="text-center">Parent’s signature</p></div> 
                                

                         </div>

                           <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12">
                             <button type="button" class="btn btn-primary IEP_btn">Submit</button>
                         </div>


				</div>

            <!---------------------TAB 4------------------------>
				</div>


                     <div class="tab-pane" id="iep11">
        <!--------------------------TAB 4----------------->

             <div class="PrintArea area4 all demo IEP_Grade11" id="Retain">
          
                        

                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="row rowdisplayflex headerwithlogo">
           <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass">

                        </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">
                  
                       <h2 class="schoolname">The City School</h2>
                        <h6>Academic Session 2020-21</h6>
                       <h5>Individual Educational Plan [IEP] – Grade 11 – O Levels Students</h5>
                      </div>
                      <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-right schoollogo">
                      <img src="Component_Marks/ReportCard/images/logo.png" />
                       </div>
                       </div>

                      </div>
                               <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center tr_headingcolor">
                                     <p>Student Detail</p>
                               </div>
                        <table class="table table-bordered custom_table_styling">
                     
                            <tr><td>Name</td><td class="nopadding_tds"><%--<input type="text" class="form-control name" />--%>
                                               <select class="name form-control"></select>
                                             </td><td>Roll No</td><td class="nopadding_tds"><input type="text" class="form-control rollno" disabled="disabled"/></td></tr>
                             <tr><td>Class</td><td class="nopadding_tds"><input type="text" class="form-control classval" disabled="disabled"/></td><td>Contact No</td><td class="nopadding_tds"><input type="text" class="form-control contactno" disabled="disabled"/></td></tr>
                            <tr><td>Email</td><td class="nopadding_tds"><input type="text" class="form-control emailaddr" disabled="disabled"/></td><td>Expected Graduation Year:</td><td class="nopadding_tds"><input type="text" class="form-control graduationyear" /></td></tr>
                                <tr><td>Career Goal & Major: </td>
                                    <td class="nopadding_tds">
                                    <table class="table table-bordered custom_table_styling"><tr><td >Plan A</td><td>Plan B</td></tr>
                               <tr><td class="nopadding_tds"><input type="text" class="form-control plan_a" /></td><td class="nopadding_tds"><input type="text" class="form-control plan_b" /></td></tr>
                                   
                                    </table>
                                         </td>
                                   <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td>3- Dream Universities:</td></tr>
                                               <tr><td>3 Backup Universities:</td></tr>
                                   
                                    </table>
                                         </td>
                                    <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td class="nopadding_tds"><input type="text" class="form-control dreamuni_1" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_2" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_3" /></td></tr>
                                               <tr><td class="nopadding_tds"><input type="text" class="form-control backupuni_1" /></td><td class="nopadding_tds"><input type="text" class="form-control backupuni_2" /></td><td class="nopadding_tds"><input type="text" class="form-control backupuni_3" /></td></tr>
                                   
                                    </table>
                                         </td>
                                


                                </tr>
                        </table>

                         <h4>Academic History</h4>
                           <table class="table table-bordered custom_table_styling academic_history1 academictour">
                            <thead>
                             <tr><th>Serial #</th><th>Grade 9-Subjects</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                                
                               </tbody>
                        </table>

                  <table class="table table-bordered custom_table_styling academic_history2">
                            <thead>
                             <tr><th>Serial #</th><th>CAIE Results</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                               <%-- <tr>
                                 <td>1</td><td>Pakistan Studies</td><td>131</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value=""/></td>
                                </tr>
                                    <tr>
                                 <td>2</td><td>Urdu</td><td>133</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value=""/></td>
                                 </tr>
                                    <tr>
                                        <td>3</td><td>Islamiyat</td><td>17</td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" data-value=""/></td>
                                         </tr>--%>
                               
                               </tbody>
                        </table>

                          <h4>Teacher Feedback</h4>
                         <div class="teacherfeedbacktable"></div>
                          <h4>Personal Information</h4>
                     <p>Is there anything else you would like for someone writing a recommendation to know about you? (Hardships you 
                        have overcome, accomplishments you are particularly proud of etc.):</p>
                           <textarea class="form-control personal_info" rows="4"></textarea>
                             <h4>Personal Strengths</h4>
                     <ol class="personalstrength border_bottom_list">
                            <li><input type="text" class="form-control personalstrength_1" /></li>
                            <li><input type="text" class="form-control personalstrength_2" /></li>
                            <li><input type="text" class="form-control personalstrength_3" /></li>
                      </ol>

                                <h4>Qualities to Develop</h4>
                     <ol class="qualitydevelop border_bottom_list">
                            <li><input type="text" class="form-control qualitydevelop_1" /></li>
                            <li><input type="text" class="form-control qualitydevelop_2" /></li>
                            <li><input type="text" class="form-control qualitydevelop_3" /></li>
                      </ol>

                             <h4>Hobbies/Interests</h4>
                
                         <textarea class="form-control hobbies_interest" rows="4"></textarea>


                          
                    <h4>Study habits (hours/pattern):</h4> 
 
                    <ul><li>hours/ day</li></ul>

<h4>Activities Information:</h4>
                         <p>(Academic clubs, Sports, Extra Curriculars, Community-based Clubs)</p>
                           <table class="table table-bordered custom_table_styling activitiestable">
                            <thead>
                                <tr><th>Organization</th><th>Brief description</th><th>Dates participated</th> <th>Leadership Roles</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>


                         <h4>Community Service:</h4>
                         <p>Many colleges and scholarship programs emphasize community service. List ways in which you have given back to the community. Give dates, approximate hours you spent and what you did.</p>
                           <table class="table table-bordered custom_table_styling communitiestable">
                            <thead>
                                <tr><th>Organization/Location</th><th>Brief description of service provided</th><th>Dates participated</th> <th>Hours spent</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>

                          
                         
               

                         
                         <p>Name two City School teachers who know you well and would speak highly of you:</p>
                         <ol class="nameofcity border_bottom_list">
                             <li><input class="form-control" /></li>
                              <li><input class="form-control" /></li>
                         </ol>

                         <h4>Questions for Parents:</h4>
                         <ol class="question_parent border_bottom_list">
                             <li><p>In your opinion, what are his/her strengths and weaknesses?</p><input class="form-control" /></li>
                              <li><p>How does he/she learn best?</p><input class="form-control" /></li>
                              <li><p>What are your long-term goals for him/her?</p><input class="form-control" /></li>
                         </ol>

                         <h4>Comments/Recommendations made by Counselor: </h4>
                
                         <textarea class="form-control comments_counsler" rows="4"></textarea>
                          <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 abovetxt">
                              <p>The above information is true and accurate to the best of my knowledge:</p>
                          </div>
                         <div class="row">
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control student_sign border_bottomtextbox"/><p class="text-center">Student’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control pri_sign border_bottomtextbox"/><p class="text-center">Principal’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control parent_sign border_bottomtextbox"/><p class="text-center">Parent’s signature</p></div> 
                                

                         </div>

                           <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12">
                             <button type="button" class="btn btn-primary IEP_btn">Submit</button>
                         </div>


				</div>

            <!---------------------TAB 4------------------------>
				</div>
                 
               <div class="tab-pane" id="iepasa">
        <!--------------------------TAB 4----------------->

             <div class="PrintArea area5 all demo IEP_ASA2" id="Retain">
          
                        

                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="row rowdisplayflex headerwithlogo">
           <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass">

                        </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">
                  
                       <h2 class="schoolname">The City School</h2>
                        <h6>Academic Session 2020-21</h6>
                       <h5>Individual Educational Plan [IEP] – AS/A2 Students </h5>
                      </div>
                      <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-right schoollogo">
                      <img src="Component_Marks/ReportCard/images/logo.png" />
                       </div>
                       </div>

                      </div>
                               <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center tr_headingcolor">
                                     <p>Student Detail</p>
                               </div>
                        <table class="table table-bordered custom_table_styling">
                     
                            <tr><td>Name</td><td class="nopadding_tds"><%--<input type="text" class="form-control name" />--%>
                                               <select class="name form-control"></select>
                                             </td><td>Roll No</td><td class="nopadding_tds"><input type="text" class="form-control rollno" disabled="disabled"/></td></tr>
                             <tr><td>Class</td><td class="nopadding_tds"><input type="text" class="form-control classval" disabled="disabled"/></td><td>Contact No</td><td class="nopadding_tds"><input type="text" class="form-control contactno" disabled="disabled"/></td></tr>
                            <tr><td>Email</td><td class="nopadding_tds"><input type="text" class="form-control emailaddr" disabled="disabled"/></td><td>Expected Graduation Year:</td><td class="nopadding_tds"><input type="text" class="form-control graduationyear" /></td></tr>
                                <tr><td>Career Goal & Major: </td>
                                    <td class="nopadding_tds">
                                    <table class="table table-bordered custom_table_styling"><tr><td >Plan A</td><td>Plan B</td></tr>
                               <tr><td class="nopadding_tds"><input type="text" class="form-control plan_a" /></td><td class="nopadding_tds"><input type="text" class="form-control plan_b" /></td></tr>
                                   
                                    </table>
                                         </td>
                                   <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td>3- Dream Universities:</td></tr>
                                               <tr><td>3 Backup Universities:</td></tr>
                                   
                                    </table>
                                         </td>
                                    <td class="nopadding_tds">
                                               <table class="table table-bordered custom_table_styling"><tr><td class="nopadding_tds"><input type="text" class="form-control dreamuni_1" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_2" /></td><td class="nopadding_tds"><input type="text" class="form-control dreamuni_3" /></td></tr>
                                               <tr><td class="nopadding_tds"><input type="text" class="form-control backupuni_1" /></td><td class="nopadding_tds"><input type="text" class="form-control backupuni_2" /></td><td class="nopadding_tds"><input type="text" class="form-control backupuni_3" /></td></tr>
                                   
                                    </table>
                                         </td>
                                


                                </tr>
                        </table>

                         <h4>Academic History</h4>
                           <table class="table table-bordered custom_table_styling academic_history1 academchange academictour">
                            <thead>
                             <tr><th>Serial #</th><th>A Level-Subjects</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                                
                               </tbody>
                        </table>

                  <table class="table table-bordered custom_table_styling academic_history2 academchange">
                            <thead>
                             <tr><th>Serial #</th><th>O Level-Subjects</th> <th>Subject_ID</th><th>Percentage</th><th>Grades (%)</th> </tr>
                            </thead>
                               <tbody>
                                
                               </tbody>
                        </table>

                          <h4>Teacher Feedback</h4>
                         <div class="teacherfeedbacktable"></div>
                          <h4>Personal Information</h4>
                     <p>Is there anything else you would like for someone writing a recommendation to know about you? (Hardships you 
                        have overcome, accomplishments you are particularly proud of etc.):</p>
                           <textarea class="form-control personal_info" rows="4"></textarea>
                             <h4>Personal Strengths</h4>
                     <ol class="personalstrength border_bottom_list">
                            <li><input type="text" class="form-control personalstrength_1" /></li>
                            <li><input type="text" class="form-control personalstrength_2" /></li>
                            <li><input type="text" class="form-control personalstrength_3" /></li>
                      </ol>

                                <h4>Qualities to Develop</h4>
                     <ol class="qualitydevelop border_bottom_list">
                            <li><input type="text" class="form-control qualitydevelop_1" /></li>
                            <li><input type="text" class="form-control qualitydevelop_2" /></li>
                            <li><input type="text" class="form-control qualitydevelop_3" /></li>
                      </ol>

                             <h4>Hobbies/Interests</h4>
                
                         <textarea class="form-control hobbies_interest" rows="4"></textarea>


                          
                    <h4>Study habits (hours/pattern):</h4> 
 
                    <ul><li>hours/ day</li></ul>

<h4>Activities Information:</h4>
                         <p>(Academic clubs, Sports, Extra Curriculars, Community-based Clubs)</p>
                           <table class="table table-bordered custom_table_styling activitiestable">
                            <thead>
                                <tr><th>Organization</th><th>Brief description</th><th>Dates participated</th> <th>Leadership Roles</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>


                         <h4>Community Service:</h4>
                         <p>Many colleges and scholarship programs emphasize community service. List ways in which you have given back to the community. Give dates, approximate hours you spent and what you did.</p>
                           <table class="table table-bordered custom_table_styling communitiestable">
                            <thead>
                                <tr><th>Organization/Location</th><th>Brief description of service provided</th><th>Dates participated</th> <th>Hours spent</th> </tr>
                            </thead>
                               <tbody>
                                   <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_2" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_3" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_4" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_5" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_6" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_7" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_8" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                                    <tr><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td><td class="nopadding_tds"><input type="text" class="form-control acasub_1" /></td></tr>
                               </tbody>
                        </table>

                          
                         
               

                         
                         <p>Name two City School teachers who know you well and would speak highly of you:</p>
                         <ol class="nameofcity border_bottom_list">
                             <li><input class="form-control" /></li>
                              <li><input class="form-control" /></li>
                         </ol>

                         <h4>Questions for Parents:</h4>
                         <ol class="question_parent border_bottom_list">
                             <li><p>In your opinion, what are his/her strengths and weaknesses?</p><input class="form-control" /></li>
                              <li><p>How does he/she learn best?</p><input class="form-control" /></li>
                              <li><p>What are your long-term goals for him/her?</p><input class="form-control" /></li>
                         </ol>

                         <h4>Comments/Recommendations made by Counselor: </h4>
                
                         <textarea class="form-control comments_counsler" rows="4"></textarea>
                          <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 abovetxt">
                              <p>The above information is true and accurate to the best of my knowledge:</p>
                          </div>
                         <div class="row">
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control student_sign border_bottomtextbox"/><p class="text-center">Student’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control pri_sign border_bottomtextbox"/><p class="text-center">Principal’s signature</p></div> 
                             <div class="col-lg-4 col-md-4 col-xs-4 col-sm-4 text-center"><input type="text" class="form-control parent_sign border_bottomtextbox"/><p class="text-center">Parent’s signature</p></div> 
                                

                         </div>

                           <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12">
                             <button type="button" class="btn btn-primary IEP_btn">Submit</button>
                         </div>


				</div>

            <!---------------------TAB 4------------------------>
				</div>
			</div>
  </div>

                <div class="floating_btn">
    <button type="button" class="tourbtn">
      <div class="contact_icon startpluse">
        <i class="fa fa-question-circle"></i>
      </div>
    </button>
    <p class="text_icon">Start the Tour?</p>
  </div>


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
                            <div class="settingVals printwalecheckbox">
                                <input type="checkbox" class="selPA sett1" value="area1" checked/> Area 1<br>
                                <input type="checkbox" class="selPA sett2" value="area2"  /> Area 2<br>
                                <input type="checkbox" class="selPA sett3" value="area3"  /> Area 3<br>
                                   <input type="checkbox" class="selPA sett4" value="area4"  /> Area 4<br>
                                     <input type="checkbox" class="selPA sett5" value="area5"  /> Area 5<br>
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
   <!--MODEL-->
    <div class="modal fade IEPModel" id="IEPModel" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Bifurcation Students</h4>
        </div>
        <div class="modal-body">
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
    <!--MODEL-->

 
    <style>
        .iep_printbtn {
        padding:10px 0px;
        }
    </style>

    
    <style>


.chariot-tooltip {
  background-color: #fff;
  padding: 30px;
  width: 320px;
  text-align: center;
  box-shadow: 0 0 5px 0 rgba(31, 28, 28, 0.3);
  border: 1px solid #ddd;
  color: #999;
  border-radius:20px;
}

.chariot-tooltip .chariot-tooltip-icon {
  width: 52px;
  height: 52px;
  margin: auto;
}

.chariot-tooltip .chariot-tooltip-icon img {
  width: 52px;
  height: 52px;
}

.chariot-tooltip .chariot-tooltip-header {
  font-size: 18px;
  line-height: 18px;
  font-weight: 500;
  color: #555;
  padding: 5px 0;
}

.chariot-tooltip .chariot-tooltip-content { padding: 5px 0; }

.chariot-tooltip .chariot-tooltip-content p {
  font-size: 14px;
  font-weight: 300;
  color: #999;
  padding-bottom: 15px;
}

.chariot-tooltip .chariot-btn-row { padding-top: 5px; }

.chariot-tooltip .chariot-btn-row .btn {
  font-size: 13px;
  font-weight: 400;
  color: #fff;
  background-color: #0c4da2;
  border-radius: 3px;
  height: 36px;
  padding: 0 20px;
  border: none;
}

.chariot-tooltip .chariot-btn-row .btn:hover { background-color: #78A300; }

.chariot-tooltip .chariot-btn-row .chariot-tooltip-subtext {
  float: left;
  color: #ddd;
  font-size: 13px;
  padding-top: 10px;
}

.chariot-tooltip-arrow { background: #fff; }

.chariot-tooltip-arrow-left {
  border-left: 1px solid #ddd;
  border-bottom: 1px solid #ddd;
  box-shadow: -2px 2px 2px 0 rgba(31, 28, 28, 0.1);
}

.chariot-tooltip-arrow-right {
  border-right: 1px solid #ddd;
  border-top: 1px solid #ddd;
  box-shadow: 2px -2px 2px 0 rgba(31, 28, 28, 0.1);
}

.chariot-tooltip-arrow-top {
  border-left: 1px solid #ddd;
  border-top: 1px solid #ddd;
  box-shadow: -2px -2px 4px 0 rgba(31, 28, 28, 0.1);
}

.chariot-tooltip-arrow-bottom {
  border-right: 1px solid #ddd;
  border-bottom: 1px solid #ddd;
  box-shadow: 2px 2px 4px 0 rgba(31, 28, 28, 0.1);
}

.chariot-btn-row .btn {
   background-color: #0c4da2 !important;
    border-color: #0c4da2 !important;
    color: #FFFFFF !important;
    border-radius:3px !important;
}

.tourbtn {
    background: none;
    border: none;
}
.floating_btn {
  position: fixed;
  bottom: 30px;
  right: 30px;
  width: 100px;
  height: 100px;
  display: flex;
  flex-direction: column;
  align-items:center;
  justify-content:center;
  /*z-index: 1000;*/
}

@keyframes pulsing {
  to {
    box-shadow: 0 0 0 30px rgba(232, 76, 61, 0);
  }
}

.contact_icon {
  background-color: #0c4da2;
  color: #fff;
  width: 60px;
  height: 60px;
  font-size:30px;
  border-radius: 50px;
  text-align: center;
  box-shadow: 2px 2px 3px #999;
  display: flex;
  align-items: center;
  justify-content: center;
  transform: translatey(0px);
  animation: pulse 1.5s infinite;
  box-shadow: 0 0 0 0 #0c4da2;
  -webkit-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  -moz-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  -ms-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  font-weight: normal;
  font-family: sans-serif;
  text-decoration: none !important;
 transition: all 300ms ease-in-out;
}

.contact_icon_pulse_stop {
  background-color: #42db87;
  color: #fff;
  width: 60px;
  height: 60px;
  font-size:30px;
  border-radius: 50px;
  text-align: center;
  box-shadow: 2px 2px 3px #999;
  display: flex;
  align-items: center;
  justify-content: center;
  /*//transform: translatey(0px);
  //animation: pulse 1.5s infinite;*/
  box-shadow: 0 0 0 0 #42db87;
  /*-webkit-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  -moz-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  -ms-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);*/
  font-weight: normal;
  font-family: sans-serif;
  text-decoration: none !important;
 /*// transition: all 300ms ease-in-out;*/
}



.text_icon {

  color: #707070;
  font-size: 13px;
}

.chariot-clone {
    color: #fff !important;
    line-height: 0px !important;
    /* block-size: 34px !important; */
}
</style>
<link href="../Styles/js/chariot.css" rel="stylesheet" />
<script src="../Styles/js/chariot.js"></script>
<script>
    $(".tourbtn").click(function () {
        var currentidoftour=$(".classtab li.active").attr('data-title');

        chariot.startTutorial({
            steps: [

                
                  {
                    selectors: ".ieppendingstudent",//"#ContentPlaceHolder1_ddl_sub_problem",
                    tooltip: {
                        position: 'bottom',
                        title: 'Pending Student',
                        text: 'Show Bifrucated Pending Student',


                    }

                },
                {
                    selectors: ".printbtn",//"#ContentPlaceHolder1_ddl_sub_problem",
                    tooltip: {
                        position: 'bottom',
                        title: 'Print Student',
                        text: 'Print IEP Form',


                    }

                },
                {
                    selectors: "#"+currentidoftour+" .name",//"#ContentPlaceHolder1_ddl_sub_problem",
                    tooltip: {
                        position: 'right',
                        title: 'Student Dropdown List',
                        text: 'List of Student',


                    }

                },
                {
                    selectors: "#" + currentidoftour +" .academictour",//"#ContentPlaceHolder1_ddl_sub_problem",
                    tooltip: {
                        position: 'top',
                        title: 'Academic History',
                        text: 'Academic history will be shown on basis of student selection',


                    }

                },

                {
                    selectors: "#"+currentidoftour+" .teacherfeedbacktable",
                    tooltip: {
                        position: 'top',
                        title: 'Teacher Feedback',
                        text: 'Teacher can give feedback of each subjects',
                    },
                },
                {
                    selectors: "#"+currentidoftour+" .personal_info",
                    tooltip: {
                        position: 'top',
                        title: 'Personal Information',
                        text: 'Enter personal information here',

                    },
                },
                {
                    selectors: "#"+currentidoftour+" .personalstrength",
                    tooltip: {
                        position: 'top',
                        title: 'Personal Strength',
                        text: 'Enter personal strength here',

                    },
                },
                {
                    selectors: "#"+currentidoftour+" .qualitydevelop",
                    tooltip: {
                        position: 'top',
                        title: 'Quality Develop',
                        text: 'Enter quality develop here',

                    },
                },
                {
                    selectors: "#"+currentidoftour+" .hobbies_interest",
                    tooltip: {
                        position: 'top',
                        title: 'Hobbies Interest',
                        text: 'Enter hobbies interest here',

                    },
                },
                {
                    selectors: "#"+currentidoftour+" .activitiestable",
                    tooltip: {
                        position: 'top',
                        title: 'Activities Information',
                        text: 'Enter activities information here',

                    },
                },
                {
                    selectors: "#"+currentidoftour+" .communitiestable",
                    tooltip: {
                        position: 'top',
                        title: 'Communties Information',
                        text: 'Enter communties information here',

                    },
                },
                {
                    selectors: "#"+currentidoftour+" .question_parent",
                    tooltip: {
                        position: 'top',
                        title: 'Question Parent',
                        text: 'Enter question parent here',

                    },
                },
                {
                    selectors: "#"+currentidoftour+" .comments_counsler",
                    tooltip: {
                        position: 'top',
                        title: 'Comments Counsler',
                        text: 'Enter comments counsler here',

                    },
                },
                {
                    selectors: "#"+currentidoftour+" .IEP_btn",
                    tooltip: {
                        position: 'right',
                        title: 'Save Form',
                        text: 'Save IEP Record',
                        className: 'dones'
                    },
                }



            ],
            onComplete: function () {
                $(".startpluse").removeClass("contact_icon_pulse_stop");
                $(".startpluse").addClass("contact_icon");
            }
            // overlayColor: 'rgba(0,0,0,0.5)'
        });


    });




</script>


</asp:Content>







