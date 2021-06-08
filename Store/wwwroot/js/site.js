// Layout

function showAccountMenu() {
	document.querySelector(".exit-account").style.display = 'block';
}

function hideAccountMenu() {
	document.querySelector(".exit-account").style.display = 'none';
}

function zoomMedia(itemNumber) {
	let items = document.querySelectorAll('.gallery > *');
	let media = items[itemNumber];

	let mediaProp = {
		src: media.getAttribute('src'),
		alt: media.getAttribute('alt'),
		title: media.getAttribute('title')
	};

	document.body.insertAdjacentHTML("afterbegin",
		`<div class="overlay"> <${media.tagName} src="${mediaProp.src}" alt="${mediaProp.alt}" title="${mediaProp.title}" controls autoplay class="full-media">` +
		`<span class="close-overlay">X</span> </div>`
	);

	let overlay = document.querySelector('div[class="overlay"]');

	overlay.onclick = () => {
		overlay.remove();
	}
}

function switchTab(tabNumber) {
	let tabs = document.querySelectorAll(".tab");
	switch (tabNumber) {
		case 1:
			document.querySelector(".users-reviews").style.display = 'block';
			tabs[0].style.background = 'rgba(30, 30, 30, 0.2)';
			tabs[1].style.background = 'rgba(0, 0, 0, 0)';
			document.querySelector(".comments").style.display = 'none';
			break;

		case 2:
			document.querySelector(".users-reviews").style.display = 'none';
			tabs[0].style.background = 'rgba(0, 0, 0, 0)';
			tabs[1].style.background = 'rgba(30, 30, 30, 0.2)';
			document.querySelector(".comments").style.display = 'block';
			break;

		default:
			alert("unknown tab");
			break;
	}
}

// Buy page

function submitPromocode() {
	switch (new String(document.querySelector("#promocode").value).toLowerCase()) {
		case 'valka': case 'valkata':
			processTotal(0);
			break;

		default:
			processTotal();
			break;
	}
	document.querySelector("#promocode").value = "";
}

function processTotal(promocode = 1) {
	let quantity = document.querySelector("#quantity").value;
	let price = 14.99;
	let comision = 1.05;

	let commonPrice = price * quantity;
	let priceWithComision = commonPrice * comision;
	let promocodeSave = priceWithComision * promocode - priceWithComision;

	document.querySelector(".price").textContent = 'Price: ' + commonPrice.toFixed(2) + '$';
	document.querySelector(".common-price-value").textContent = commonPrice.toFixed(2);
	document.querySelector(".comision-value").textContent = (priceWithComision - commonPrice).toFixed(2);
	document.querySelector(".promocode-value").textContent = promocodeSave.toFixed(2);
	document.querySelector(".total-value").textContent = (priceWithComision + promocodeSave).toFixed(2);
}

// Giveaways

function initializeGivaways() {
	isParticipate();
	clock();
}

function isParticipate() {
	if (localStorage.getItem('participating-giveaway') === 'true')
		participateInGiveaway();
}

function participateInGiveaway() {
	let button = document.querySelector('.participate');

	button.className += ' already-participate';
	button.textContent = 'Already participate';
	localStorage.setItem('participating-giveaway', 'true');
}

function clock() {
	let timeInSeconds = 14444;
	let clock = document.querySelector('.clock');
	window.setInterval(
		function () {
			hours = Math.floor(timeInSeconds / 3600);
			minutes = Math.floor((timeInSeconds - hours * 3600) / 60);
			seconds = timeInSeconds % 60 % 60;
			clock.textContent = hours + ':' + minutes + ':' + seconds;
			--timeInSeconds;
		}
		, 999);
}

// Contacts

function sendFeedback() {
	if (document.querySelector('textarea').value !== "") {
		document.querySelector('textarea').value = "";

		document.body.insertAdjacentHTML("afterbegin",
			`<div class="overlay"> <div class="feedback-sended"> <p>Thanks for feedback!</p> <br> <p>The mail was sended to support@store.com</p> </div> </div>`
		);
	}
	else
		document.body.insertAdjacentHTML("afterbegin",
			`<div class="overlay"> <div class="feedback-sended"> <p>Enter some information.</p> </div> </div>`
		);

	let overlay = document.querySelector('div[class="overlay"]');

	overlay.onclick = () => {
		overlay.remove();
	}
}