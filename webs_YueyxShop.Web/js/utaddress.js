$.fn.sjld = function (shenfen, chengshi, quyu) {
    
    $('.m_zlxg').click(function () {
        $(this).find('.m_zlxg2').slideDown(200);
    })
    $('.m_zlxg').mouseleave(function () {
        $(this).find('.m_zlxg2').slideUp(200);
    })
    

    /*---------------------------------------------------------------------*/

    $(sfli).click(function () {
        var dqsf = $(this).text();
        $(shenfen).find('p').text(dqsf);
        $(shenfen).find('p').attr('title', dqsf);
        var sfnum = $(this).index();

        var csgs = provinceList[sfnum].cityList;
        var csgs2 = provinceList[sfnum].cityList[0].areaList;
        $(chengshi).find('ul').text('');
        var kuandu = new Array();
        for (i = 0; i < csgs.length; i++) {
            var csmc = csgs[i].name;
            var csnr = "<li>" + csmc + "</li>";
            $(chengshi).find('ul').append(csnr);
            kuandu[i] = csmc.length * 14 + 20;
        }
        Array.max = function (array) {
            return Math.max.apply(Math, array);
        }
        var max_kd = Array.max(kuandu);
        if (max_kd < 91) {
            $(css).width('91px');
        }
        else {
            $(css).width(max_kd);
        }
        var qygsdqmr = provinceList[sfnum].cityList[0].areaList;
        $(quyu).find('ul').text('');
        for (j = 0; j < qygsdqmr.length; j++) {
            var qymc = qygsdqmr[j];
            var qynr = "<li>" + qymc + "</li>";
            $(quyu).find('ul').append(qynr);
        }
        $(csp).text(csgs[0].name);
        $(qyp).text(csgs2[0]);
        $('#sfdq_num').val(sfnum);

        /*------------------*/
        $(csli).click(function () {
            var dqcs = $(this).text();
            var dqsf_num = $('#sfdq_num').val();
            if (dqsf_num == "") {
                dqsf_num = 0;
            }
            else {
                var dqsf_num = $('#sfdq_num').val();
            }
            $(chengshi).find('p').text(dqcs);
            $(chengshi).find('p').attr('title', dqcs);
            var csnum = $(this).index();
            var qygs = provinceList[dqsf_num].cityList[csnum].areaList;
            $(quyu).find('ul').text('');
            for (j = 0; j < qygs.length; j++) {
                var qymc = qygs[j];
                var qynr = "<li>" + qymc + "</li>";
                $(quyu).find('ul').append(qynr);
            }

            $(qyp).text(qygs[0]);
            $('#csdq_num').val(csnum);

            $(this).parents('.m_zlxg2').width(kuandu);
            $(qyli).click(function () {
                var dqqy = $(this).text();
                $(quyu).find('p').text(dqqy);
                $(quyu).find('p').attr('title', dqqy);

            })//区级
        })	//市级
        /*------------------*/
        $(qyli).click(function () {
            var dqqy = $(this).text();
            $(quyu).find('p').text(dqqy);
            $(quyu).find('p').attr('title', dqqy);

        })//区级


    })//省级
    /*---------------------------------------------------------------------*/



    $(csli).click(function () {
        var dqcs = $(this).text();
        var dqsf_num = $('#sfdq_num').val();
        if (dqsf_num == "") {
            dqsf_num = 0;
        }
        else {
            var dqsf_num = $('#sfdq_num').val();
        }
        $(chengshi).find('p').text(dqcs);
        $(chengshi).find('p').attr('title', dqcs);
        var csnum = $(this).index();
        var qygs = provinceList[dqsf_num].cityList[csnum].areaList;
        $(quyu).find('ul').text('');
        for (j = 0; j < qygs.length; j++) {
            var qymc = qygs[j];
            var qynr = "<li>" + qymc + "</li>";
            $(quyu).find('ul').append(qynr);
        }
        $(qyp).text(qygs[0]);
        $('#csdq_num').val(csnum);
        /*------------------*/
        $(qyli).click(function () {
            var dqqy = $(this).text();
            $(quyu).find('p').text(dqqy);
            $(quyu).find('p').attr('title', dqqy);


        })//区级
    })	//市级
    /*---------------------------------------------------------------------*/

    $(qyli).click(function () {
        var dqqy = $(this).text();
        $(quyu).find('p').text(dqqy);
        $(quyu).find('p').attr('title', dqqy);


    })//区级

    /*---------------------------------------------------------------------*/
    $('.m_zlxg').click(function () {
        $('#sfdq_tj').val($(sfp).text());
        $('#csdq_tj').val($(csp).text());
        $('#qydq_tj').val($(qyp).text());
    })//表单传值获取

}
