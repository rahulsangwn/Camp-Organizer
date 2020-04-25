import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

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
  constructor() { }

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

  onSubmit(form: NgForm) {
    console.log(form)
  }

}
