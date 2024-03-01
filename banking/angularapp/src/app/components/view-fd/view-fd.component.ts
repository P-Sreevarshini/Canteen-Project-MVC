import { Component, OnInit } from '@angular/core';
import { FixedDepositService } from '../../services/fixed-deposit.service';
import { FixedDeposit } from 'src/app/models/fixedDeposit.model';
import { UserRoles } from 'src/app/models/userRole.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-view-fd',
  templateUrl: './view-fd.component.html',
  styleUrls: ['./view-fd.component.css']
})
export class ViewFdComponent implements OnInit {
  fds: FixedDeposit[];
  selectedFd: FixedDeposit;
  userRole: string;
  userId : number;

  constructor(private fdService: FixedDepositService,private authService: AuthService) { }

  ngOnInit(): void {
    this.getAllFd();
    this.userRole = localStorage.getItem('userRole'); // get the user's role from local storage
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = this.authService.decodeToken(token);
      if (decodedToken) {
        this.userRole = decodedToken.role;
      }
    }
  }


  getAllFd(): void {
    this.fdService.getAllFd().subscribe(fds => {
      this.fds = fds;
      console.log(fds);
    });
  }

editFd(fd: FixedDeposit): void {
  console.log('User Role:', this.userRole);

  if (this.userRole !== 'Admin') {
    console.error('Access denied. Only admins can edit FDs.');
    return;
  }
}

  deleteFd(fd: FixedDeposit): void {
    if (this.userRole !== 'Admin') {
      console.error('Access denied. Only admins can delete FDs.');
      return;
    }

    this.fdService.deleteFdByAdmin(fd.fixedDepositId).subscribe(() => {
      this.getAllFd(); // refresh the list after deleting
    });
  }

  // updateFd(fd: FixedDeposit): void {
  //   if (this.userRole !== 'Admin') {
  //     console.error('Access denied. Only admins can update FDs.');
  //     return;
  //   }

  //   this.fdService.updateFdByAdmin(fd.fixedDepositId, fd).subscribe(() => {
  //     this.getAllFd(); // refresh the list after updating
  //     this.selectedFd = null; // clear the selection
  //   });
  // }

  cancelEdit(): void {
    this.selectedFd = null; 
  }
}
