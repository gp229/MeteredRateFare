import {Component, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Fare} from './Fare';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  fare = new Fare(undefined, undefined, undefined);
  value;
  http;
  headers = new HttpHeaders({'Content-Type': 'application/json'});

  onSubmit() {
    this.http.post(document.getElementsByTagName('base')[0].href + 'faremeter/getfare',
      JSON.stringify(this.fare), {headers: this.headers}).subscribe(result => {
      this.value = result;
    }, error => console.error(error));

    this.fare = new Fare(undefined, undefined, undefined);
  }

  constructor(http: HttpClient) {
    this.http = http;
  }
}


