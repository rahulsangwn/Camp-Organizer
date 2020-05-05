import { Component, OnInit } from '@angular/core';
import { Camp } from 'src/app/camp.model';
import { JsonPipe } from '@angular/common';
import { take, exhaustMap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AuthService } from 'src/app/admin-module/auth/auth.service';

@Component({
  selector: 'app-camp-edit',
  templateUrl: './camp-edit.component.html',
  styleUrls: ['./camp-edit.component.scss']
})
export class CampEditComponent implements OnInit {
  camp: Camp = null

  file: File;
  base64textString: string
  imageUrl: string | ArrayBuffer = "assets/img/camp3.png";
  fileName: string = "Select New Image to Update"
  newImageUploaded = false

  constructor(private router: Router, private http: HttpClient, private authService: AuthService) { }

  ngOnInit(): void {
    this.camp = JSON.parse(localStorage.getItem('camp'));
    localStorage.removeItem('camp')

    this.imageUrl = this.camp.image
    console.log(this.camp)
  }

  onUpdate(data: Camp) {
    if(this.newImageUploaded) {
      data["image"] = 'data:image/jpg;base64,' + this.base64textString
    } else {
      data["image"] = this.camp.image
    }

    data["campId"] = this.camp.campId

    this.updateCamp(data).subscribe(resData => {
      this.router.navigate(['/'])
      // console.log(resData)
    })
  }

  updateCamp(camp) {
    return this.authService.admin.pipe(
      take(1), 
      exhaustMap(admin => {
        return this.http.put<Camp>('http://localhost:8080/api/admin', camp)
      }))
  }

  handleReaderLoaded(readerEvt) {
    var binaryString = readerEvt.target.result;
    this.base64textString= btoa(binaryString);
    //console.log(btoa(binaryString));
  }

  onFileChange(file: File) {
    if (file) {
      this.fileName = file.name
      this.file = file

      this.newImageUploaded = true

      const reader = new FileReader()
      const reader2 = new FileReader()
      
      reader.onload =this.handleReaderLoaded.bind(this)
      reader.readAsBinaryString(file);

      reader2.readAsDataURL(file)
      reader2.onload = event => {
          this.imageUrl = reader2.result;
      };
    }
  }
}
