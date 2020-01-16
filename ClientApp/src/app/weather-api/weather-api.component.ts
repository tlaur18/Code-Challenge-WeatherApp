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
        this.forecast = response["forecast"]["conditions"][0],
        this.removeNulls(this.report),
        this.removeNulls(this.forecast)
    }, error => console.error(error));
  }

  removeNulls(obj: any) {
    let array = Object.values(obj);
    for (var i = 0; i < array.length; i++) {
      let currentObject = array[i];
      if (typeof (currentObject) === "string") {
        continue;
      } else if (currentObject === null) {
        obj[Object.keys(obj)[i]] = "Not specified."
      } else if (Object.values(currentObject).length !== 0) {
        this.removeNulls(currentObject);
      }
    }
  }
}
