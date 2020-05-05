import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Camp } from 'src/app/camp.model';
import { AuthService } from '../auth/auth.service';
import { take, exhaustMap, map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-camp-create',
  templateUrl: './camp-create.component.html',
  styleUrls: ['./camp-create.component.scss']
})
export class CampCreateComponent implements OnInit {

  file: File;
  base64textString: string
  imageUrl: string | ArrayBuffer =
  "assets/img/camp3.png";
  fileName: string = "No file selected"
  constructor(private http: HttpClient, private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
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

  onSubmit(data : Camp) {
    data["image"] = 'data:image/jpg;base64,' + this.base64textString

    this.createCamp(data).subscribe(resData => {
      this.router.navigate(['/'])
      // console.log(resData)
    })
  }
  
  createCamp(camp) {
    return this.authService.admin.pipe(
      take(1), 
      exhaustMap(admin => {
        return this.http.post<Camp>('http://localhost:8080/api/admin', camp)
      }))
  }

}
