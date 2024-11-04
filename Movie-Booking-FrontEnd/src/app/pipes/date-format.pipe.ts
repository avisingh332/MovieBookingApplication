import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateFormat'
})
export class DateFormatPipe implements PipeTransform {
  transform(value: Date | string): string {
    // Ensure the value is a Date object
    const date = typeof value === 'string' ? new Date(value) : value;
    
    // Extract the day, month, and year
    const day = date.getDate();
    const month = date.toLocaleString('default', { month: 'long' }); // Full month name
    const year = date.getFullYear();

    // Get the correct ordinal suffix for the day
    const dayWithSuffix = this.addOrdinalSuffix(day);

    return `${dayWithSuffix} ${month} ${year}`;
  }

  // Method to add the ordinal suffix to the day
  private addOrdinalSuffix(day: number): string {
    if (day > 3 && day < 21) return day + 'th'; // Special case for 11th to 20th
    switch (day % 10) {
      case 1: return day + 'st';
      case 2: return day + 'nd';
      case 3: return day + 'rd';
      default: return day + 'th';
    }
  }
}