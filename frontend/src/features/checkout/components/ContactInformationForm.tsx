import {
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import { Separator } from '@/components/ui/separator';
import { useFormContext, useWatch } from 'react-hook-form';
import type { Billing } from './BillingForm';
import { useCountries } from '../hooks/useCountries';
import { useCities } from '../hooks/useCities';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function ContactInformationForm() {
  const { handleSubmit, control } = useFormContext<Billing>();
  const selectedCountryId = useWatch({ control, name: 'countryId'});
  const {
    components: { contactInformationForm },
  } = useTranslation();

  console.log(selectedCountryId)

  const { data: countries = [] } = useCountries();
  const { data: cities = [] } = useCities(selectedCountryId);

  function onSubmit(values: Billing) {
    console.log(values);
  }

  return (
    <form onSubmit={handleSubmit(onSubmit)} className='space-y-6 w-full'>
      <div className='space-y-2'>
        <div className='grid grid-cols-1 md:grid-cols-2 gap-4'>
          <FormField
            control={control}
            name='countryId'
            render={({ field }) => (
              <FormItem className='w-full'>
                <FormLabel>{contactInformationForm.country}</FormLabel>
                <Select
                  onValueChange={(val) => field.onChange(Number(val))}
                  value={field.value?.toString() ?? ''}
                >
                  <FormControl>
                    <SelectTrigger className='w-full'>
                      <SelectValue placeholder={contactInformationForm.selectCountry} />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    {countries.map((country) => (
                      <SelectItem
                        key={country.id}
                        value={country.id.toString()}
                      >
                        {country.countryName}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={control}
            name='cityId'
            render={({ field }) => (
              <FormItem className='w-full'>
                <FormLabel>{contactInformationForm.city}</FormLabel>
                <Select
                  onValueChange={(val) => field.onChange(Number(val))}
                  value={field.value?.toString() ?? ''}
                  disabled={selectedCountryId === undefined}
                >
                  <FormControl>
                    <SelectTrigger className='w-full'>
                      <SelectValue placeholder={contactInformationForm.selectCity} />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    {cities.map((city) => (
                      <SelectItem key={city.id} value={city.id.toString()}>
                        {city.cityName}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />
        </div>
      </div>

      <Separator />

      <div className='space-y-2'>
        <div className='grid grid-cols-1 md:grid-cols-2 gap-4'>
          <FormField
            control={control}
            name='streetName'
            render={({ field }) => (
              <FormItem>
                <FormLabel>{contactInformationForm.streetName}</FormLabel>
                <FormControl>
                  <Input {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={control}
            name='streetNumber'
            render={({ field }) => (
              <FormItem>
                <FormLabel>{contactInformationForm.streetNumber}</FormLabel>
                <FormControl>
                  <Input
                    type='number'
                    {...field}
                    onChange={(e) => field.onChange(Number(e.target.value))}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        </div>
      </div>

      <Separator />

      <div className='space-y-2'>
        <div className='grid grid-cols-1 md:grid-cols-2 gap-4'>
          <FormField
            control={control}
            name='floor'
            render={({ field }) => (
              <FormItem>
                <FormLabel>{contactInformationForm.floor}</FormLabel>
                <FormControl>
                  <Input
                    type='number'
                    {...field}
                    onChange={(e) => field.onChange(Number(e.target.value))}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={control}
            name='apartmentNumber'
            render={({ field }) => (
              <FormItem>
                <FormLabel>{contactInformationForm.apartment}</FormLabel>
                <FormControl>
                  <Input
                    type='number'
                    {...field}
                    onChange={(e) => field.onChange(Number(e.target.value))}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        </div>
      </div>
    </form>
  );
}
