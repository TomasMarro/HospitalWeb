import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import { GlobalModule } from '../../global.module';

@Component({
  selector: 'app-menu-global',
  standalone: true,
  imports: [MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    RouterModule
  ],
  templateUrl: './menu-global.component.html',
  styleUrl: './menu-global.component.scss'
})
export class MenuGlobalComponent {

}
