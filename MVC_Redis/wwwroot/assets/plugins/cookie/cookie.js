$(document).ready(function() {
	$('body').ihavecookies({
		title: 'Tanımlama Bilgileri ve Gizlilik Politikasını Kabul Ediyor musunuz?',
		language:'tr',
		message: 'Bu sitede çerez kullanılmamaktadır, ancak olsaydı, bu mesaj daha fazla ayrıntı sağlamak için özelleştirilebilirdi.İsteğe bağlı geri aramayı çalışırken görmek için aşağıdaki <strong>kabul et</strong> düğmesini tıklayın...',
		delay: 600,
		expires: 1,
		link: '#privacy',
		onAccept: function(){
			var myPreferences = $.fn.ihavecookies.cookie();
			//console.log('Yay! The following preferences were saved...');
			//console.log(myPreferences);
		},
		uncheckBoxes: true,
		acceptBtnLabel: 'Çerezleri Kabul et',
		moreInfoLabel: 'Daha fazla bilgi',
		advancedBtnLabel: 'Çerezleri Yönet',
	});

	if ($.fn.ihavecookies.preference('marketing') === true) {
		//console.log('This should run because marketing is accepted.');
	}


});