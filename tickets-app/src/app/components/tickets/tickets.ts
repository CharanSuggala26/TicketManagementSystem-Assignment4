import { Component , signal} from '@angular/core';
import { CommonModule } from '@angular/common';
import { TicketsService } from '../../services/tickets-service';

@Component({
  selector: 'app-tickets',
  imports: [CommonModule],
  templateUrl: './tickets.html',
  styleUrl: './tickets.css',
})
export class Tickets {
  tickets = signal<any[]>([]);
  selectedTicket = signal<any>(null);

  constructor(private ticketsService: TicketsService) {
    this.loadTickets();
  }
  
  loadTickets(){
    this.ticketsService.getTickets().subscribe( data => {
      this.tickets.set(data);
    });
  }

  getTicketDetails(id : number){
    this.ticketsService.getTicketById(id).subscribe( data => {
      this.selectedTicket.set(data);
    });
  }
}
