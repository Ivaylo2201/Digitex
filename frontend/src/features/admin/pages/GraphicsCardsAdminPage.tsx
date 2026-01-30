import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
  DialogFooter,
  DialogDescription,
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';
import { Page } from '@/components/layout/Page';
import { GraphicsCardsDatatable } from '../components/GraphicsCardsDatatable';

export function GraphicsCardsAdminPage() {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <Dialog>
          <DialogTrigger asChild>
            <Button
              variant='secondary'
              className='bg-theme-gunmetal text-theme-white hover:bg-theme-gunmetal hover:text-theme-white cursor-pointer'
            >
              Add New Graphics Card
            </Button>
          </DialogTrigger>

          <DialogContent className='sm:max-w-lg'>
            <DialogHeader>
              <DialogTitle>Add New Graphics Card</DialogTitle>
              <DialogDescription>
                Fill in the details to add a new graphics card.
              </DialogDescription>
            </DialogHeader>

            <div>Create</div>

            <DialogFooter>
              <Button variant='outline'>Cancel</Button>
              <Button type='submit'>Save</Button>
            </DialogFooter>
          </DialogContent>
        </Dialog>

        <GraphicsCardsDatatable />
      </div>
    </Page>
  );
}
