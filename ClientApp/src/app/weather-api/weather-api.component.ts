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

  report;
  forecast;

  constructor(private http2: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http2;
    this.url = baseUrl;
  }

  ngOnInit() {
  }

  getData() {
    return this.http.get(this.url + "weatherapi?icaoCode=" + this.icaoCode);
  }

  onSubmit() {
    this.getData().subscribe((response: any) => {
      this.report = response["conditions"],
        this.forecast = response["forecast"]["conditions"][0];
    }, error => console.error(error));
  }
}
