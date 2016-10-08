import $ from 'jquery';

class autocomplete {
    constructor () {
        this.form = document.getElementById('form');
        this.inputs = document.getElementsByClassName('controls');
        this.init();
    }

    populateField(type, lat, lng) {
        document.getElementById(type + '-input-lat').value = lat;
        document.getElementById(type + '-input-lng').value = lng;
    }

    init() {
        Array.from(this.inputs).forEach( (input) => {
            let google = window.google;
            let autocomplete = new google.maps.places.Autocomplete(input);
            let type = input.dataset.type;

            autocomplete.addListener('place_changed', () => {
                let place = autocomplete.getPlace();
                console.log(place.geometry.location.lat(), place.geometry.location.lng())
                this.populateField(type, place.geometry.location.lat(),place.geometry.location.lng())
            });
        });

        this.form.addEventListener('submit', (e) => {
            //let data = new FormData(this.form);
            let data = $(this.form).serialize();
            console.log(data);
            e.preventDefault();
        });
    }
}

export default autocomplete;
