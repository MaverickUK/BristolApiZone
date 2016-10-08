import $ from 'jquery';

class autocomplete {
    constructor () {

        /// Elements
        this.form = document.getElementById('form');
        this.map = document.getElementById('map');
        this.inputs = document.getElementsByClassName('controls');

        /// Initialise the form
        if (this.form !== null && this.inputs.length > 0) {
            this.initForm(); 
        }

        if (this.map !== null) {
            this.initMap();
        }
        
    }

    initMap() {
        let google = window.google;

        let map = new google.maps.Map(document.getElementById('map'), {
            zoom: 14,
            center: {lat: 51.4568616, lng: -2.587910},
            mapTypeId: 'roadmap'
        });

        let polylines = [
            'yy_yHpa~NHD??R{BLyATuCLaAFi@D[?o@@KBmA?E???m@C_A?]ASAc@IcAkB{MU{AWsBGSa@oAKSQUKCEAEE?AGKCS?YBQJO@?LQNEJGBIDMFiA@q@BcB@]@{@???KB}A@]As@CoAC{@Aa@Ae@CoAEaBAeAASEgAO{AIm@Cm@MsC?I??AYCOAMOy@W{AKYMYa@i@KMk@Um@[QE[GO?K?OEQYEEs@q@QKQIgAMoB[_@Ma@UCAa@Si@g@e@e@[[',
            'mv}xHfgqNKh@m@vAE`@]?w@~Dm@|CQz@??i@lCEX{@fEQ`A??g@|Bk@dDObCAxAAlA??sBjQ??CZKhB]bFKxAGf@EVIt@O`AQxAKrAMtAEzAChB?R???lBBzCFhC@n@XvHFjB?jA?v@DjA?H???N@r@ANAdAIhBCl@G~@Kx@CLMx@YlAs@xBy@`Co@bAMVUf@k@|@s@r@WRQNOFOFOD{@VC?CBULa@XQR]\SRW\Y^aBhCGNSh@W|@Mn@Eb@Gz@EZ?PERKXEFi@~@QXEHGFKDC?]DWB[JOJKRYr@Yl@Qd@??IRSf@Yp@IXIj@C`@ALC`@Er@Ap@@`@KRIXKLE?E@MCMGYe@Y[MIGEWKKBYXQNiAjAGH_@`@EHoAtAMNEFa@`@??ONq@x@UX_@f@w@dAQ^O`@_@~@EHITGPEPEXKb@]lA'
        ]

        Array.from(polylines).forEach( (polyline) => {
            let decodedPolyline = google.maps.geometry.encoding.decodePath(polyline);

            let path = new google.maps.Polyline({
                path: decodedPolyline,
                geodesic: true,
                strokeColor: '#FF0000',
                strokeOpacity: 1.0,
                strokeWeight: 2
            });

            path.setMap(map);
        });

        let infowindow = new google.maps.InfoWindow({
            content: `<span>Hello</span>`
        });

        let marker = new google.maps.Marker({
            position: {lat: 51.454745, lng: -2.5965832},
            map: map,
            title: 'Uluru (Ayers Rock)'
        });

        marker.addListener('click', function() {
            infowindow.open(map, marker);
        });
    }   

    populateField(type, lat, lng) {
        document.getElementById(type + '-input-lat').value = lat;
        document.getElementById(type + '-input-lng').value = lng;
    }

    initForm() {
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
