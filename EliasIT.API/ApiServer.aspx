﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApiServer.aspx.cs" Inherits="EliasIT.API.ApiServer" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script>
            $(function () {
                //scrollpane parts
                var scrollPane = $(".scroll-pane"), scrollContent = $(".scroll-content");

                //build slider
                var scrollbar = $(".scroll-bar").slider({
                    slide: function (event, ui) {
                        if (scrollContent.width() > scrollPane.width()) {
                            scrollContent.css("margin-left", Math.round(
                              ui.value / 100 * (scrollPane.width() - scrollContent.width())
                            ) + "px");
                        } else {
                            scrollContent.css("margin-left", 0);
                        }
                    }
                });

                //append icon to handle
                var handleHelper = scrollbar.find(".ui-slider-handle")
                .mousedown(function () {
                    scrollbar.width(handleHelper.width());
                })
                .mouseup(function () {
                    scrollbar.width("100%");
                })
                .append("<span class='ui-icon ui-icon-grip-dotted-vertical'></span>")
                .wrap("<div class='ui-handle-helper-parent'></div>").parent();

                //change overflow to hidden now that slider handles the scrolling
                scrollPane.css("overflow", "hidden");

                //size scrollbar and handle proportionally to scroll distance
                function sizeScrollbar() {
                    var remainder = scrollContent.width() - scrollPane.width();
                    var proportion = remainder / scrollContent.width();
                    var handleSize = scrollPane.width() - (proportion * scrollPane.width());
                    scrollbar.find(".ui-slider-handle").css({
                        width: handleSize,
                        "margin-left": -handleSize / 2
                    });
                    handleHelper.width("").width(scrollbar.width() - handleSize);
                }

                //reset slider value based on scroll content position
                function resetValue() {
                    var remainder = scrollPane.width() - scrollContent.width();
                    var leftVal = scrollContent.css("margin-left") === "auto" ? 0 :
                      parseInt(scrollContent.css("margin-left"));
                    var percentage = Math.round(leftVal / remainder * 100);
                    scrollbar.slider("value", percentage);
                }

                //if the slider is 100% and window gets larger, reveal content
                function reflowContent() {
                    var showing = scrollContent.width() + parseInt(scrollContent.css("margin-left"), 10);
                    var gap = scrollPane.width() - showing;
                    if (gap > 0) {
                        scrollContent.css("margin-left", parseInt(scrollContent.css("margin-left"), 10) + gap);
                    }
                }

                //change handle position on window resize
                $(window).resize(function () {
                    resetValue();
                    sizeScrollbar();
                    reflowContent();
                });
                //init scrollbar size
                setTimeout(sizeScrollbar, 10);//safari wants a timeout
            });
  </script>
</head>
<body>

<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">

<style>
  .scroll-pane { overflow: auto; width: 99%; float:left; }
  .scroll-content { width: 2440px; float: left; }
  .scroll-content-item { width: 100px; height: 100px; float: left; margin: 10px; font-size: 3em; line-height: 96px; text-align: center; }
  .scroll-bar-wrap { clear: left; padding: 0 4px 0 2px; margin: 0 -1px -1px -1px; }
  .scroll-bar-wrap .ui-slider { background: none; border:0; height: 2em; margin: 0 auto;  }
  .scroll-bar-wrap .ui-handle-helper-parent { position: relative; width: 100%; height: 100%; margin: 0 auto; }
  .scroll-bar-wrap .ui-slider-handle { top:.2em; height: 1.5em; }
  .scroll-bar-wrap .ui-slider-handle .ui-icon { margin: -8px auto 0; position: relative; top: 50%; }
</style>

    <form id="form1" runat="server">
    <div><asp:label runat="server" id="labeltext" text="Label"></asp:label>
<div class="scroll-pane ui-widget ui-widget-header ui-corner-all">
  <div class="scroll-content">
      
      <div class="scroll-content-item ui-widget-header"> </div>
   <%-- 
    <div class="scroll-content-item ui-widget-header">2</div>
    <div class="scroll-content-item ui-widget-header">3</div>
    <div class="scroll-content-item ui-widget-header">4</div>
    <div class="scroll-content-item ui-widget-header">5</div>
    <div class="scroll-content-item ui-widget-header">6</div>
    <div class="scroll-content-item ui-widget-header">7</div>
    <div class="scroll-content-item ui-widget-header">8</div>
    <div class="scroll-content-item ui-widget-header">9</div>
    <div class="scroll-content-item ui-widget-header">10</div>
    <div class="scroll-content-item ui-widget-header">11</div>
    <div class="scroll-content-item ui-widget-header">12</div>
    <div class="scroll-content-item ui-widget-header">13</div>
    <div class="scroll-content-item ui-widget-header">14</div>
    <div class="scroll-content-item ui-widget-header">15</div>
    <div class="scroll-content-item ui-widget-header">16</div>
    <div class="scroll-content-item ui-widget-header">17</div>
    <div class="scroll-content-item ui-widget-header">18</div>
    <div class="scroll-content-item ui-widget-header">19</div>
    <div class="scroll-content-item ui-widget-header">20</div>--%>
  </div>
  <div class="scroll-bar-wrap ui-widget-content ui-corner-bottom">
    <div class="scroll-bar"></div>
  </div>
</div>
       

    </div>
    </form>
</body>
</html>