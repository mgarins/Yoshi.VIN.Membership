﻿import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'phoneFormat' })

export class PhonePipe implements PipeTransform {
    transform(tel: number, args: any) {
        if (tel === null)
            return "";
        var value = tel.toString().trim().replace(/^\+/, '');
        console.log(value);
        if (value.match(/[^0-9]/)) {
            return value;
        }

        var country: string, city: string, number: string;

        switch (value.length) {
            case 10: // +1PPP####### -> C (PPP) ###-####
                country = "1";
                city = value.slice(0, 3);
                number = value.slice(3);
                break;

            case 11: // +CPPP####### -> CCC (PP) ###-####
                country = value[0];
                city = value.slice(1, 4);
                number = value.slice(4);
                break;

            case 12: // +CCCPP####### -> CCC (PP) ###-####
                country = value.slice(0, 3);
                city = value.slice(3, 5);
                number = value.slice(5);
                break;

            default:
                return tel;
        }

        if (country === "1") {
            country = "";
        }

        number = number.slice(0, 3) + '-' + number.slice(3);

        return (country + " (" + city + ") " + number).trim();
    }
}