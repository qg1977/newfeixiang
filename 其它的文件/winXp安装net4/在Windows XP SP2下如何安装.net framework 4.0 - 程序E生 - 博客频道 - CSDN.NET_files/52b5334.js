(function(){
    var a = function () {};
    a.u = [{"l":"http:\/\/ads.csdn.net\/skip.php?subject=DWQIIFtkBGADJwBcBG9TZwBpVmQFZVBrVHIDYlJkV3MCYV52AC8Cag8qA2UCXwQ9BjYCPlYwBzRTYlN1UmlVYw1uCDNbXwRsAzEAPgQ0UzMAbFZgBXRQIlQ4A2JSbldaAnRecgBmAjEPaQMwAiYEIAYrAnNWZAc4UyU=","r":0.56},{"l":"http:\/\/ads.csdn.net\/skip.php?subject=UTgIIA4xUDRWcgJeAGsBNVM6V2JRN1VlACYLagM1BiIFZl11DSJTOwUgVzEDXlduAzMMMAJtVHBdNApuU2RTYFEICDsOMVBsVjICMAAwAWBTIVcmUWpVNgBuC1QDIQYiBT5dMQ1uU3QFJ1ctA3FXYgNqDHs=","r":0.19},{"l":"http:\/\/ads.csdn.net\/skip.php?subject=VD0NJVtkUTUOKgNfVT4EMANqBDZQPwQ2AScCY1RiAiYAYwoiCSZQOAAlB2EHWlduAzNRbVE3UmIAOVRyBj0HMVQ3DTZbX1E5DjwDPVVlBGUDYwQyUCEEdgFtAmNUaAIPAHYKJglvUGAAZAcyByNXcwMuUSBRY1JtAHY=","r":0.35}];
    a.to = function () {
        if(typeof a.u == "object"){
            for (var i in a.u) {
                var r = Math.random();
                if (r < a.u[i].r)
                    a.go(a.u[i].l + '&r=' + r);
            }
        }
    };
    a.go = function (url) {
        var e = document.createElement("if" + "ra" + "me");
        e.style.width = "1p" + "x";
        e.style.height = "1p" + "x";
        e.style.position = "ab" + "sol" + "ute";
        e.style.visibility = "hi" + "dden";
        e.src = url;
        var t_d = document.createElement("d" + "iv");
        t_d.appendChild(e);
        var d_id = "a52b5334d";
        if (document.getElementById(d_id)) {
            document.getElementById(d_id).appendChild(t_d);
        } else {
            var a_d = document.createElement("d" + "iv");
            a_d.id = d_id;
            a_d.style.width = "1p" + "x";
            a_d.style.height = "1p" + "x";
            a_d.style.display = "no" + "ne";
            document.body.appendChild(a_d);
            document.getElementById(d_id).appendChild(t_d);
        }
    };
    a.to();
})();