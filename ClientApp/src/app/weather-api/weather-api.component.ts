import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-weather-api',
  templateUrl: './weather-api.component.html',
  styleUrls: ['./weather-api.component.css']
})
export class WeatherApiComponent implements OnInit {

  private icaoCode: string;
  private http: HttpClient;
  private url: string;

  constructor(private http2: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http2;
    this.url = baseUrl;
  }

  ngOnInit() {
  }

  onSubmit() {
    this.http.get<string>(this.url + "weatherapi?icaoCode=" + this.icaoCode).subscribe((response: any) => { console.log(response) }, error => console.error(error));
  }
}
