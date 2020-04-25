import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-camp-create',
  templateUrl: './camp-create.component.html',
  styleUrls: ['./camp-create.component.scss']
})
export class CampCreateComponent implements OnInit {

  file: File;

  imageUrl: string | ArrayBuffer =
  "https://bulma.io/images/placeholders/480x480.png";
  fileName: string = "No file selected"
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
  }

  onFileChange(file: File) {
    if (file) {
      this.fileName = file.name
      this.file = file

      const reader = new FileReader()
      reader.readAsDataURL(file)

      reader.onload = event => {
        this.imageUrl = reader.result;
      };
    }
  }

  onSubmit(formData : {title: string, description: string, rate: number}) {
    console.log(formData)
    this.http.post('http://localhost:8080/api/values', formData)
    .subscribe(responseData => {
      console.log(responseData)
    })
  }

}
