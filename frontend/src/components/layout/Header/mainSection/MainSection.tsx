import AccountLink from '@/components/layout/header/mainSection/AccountLink';
import CartLink from '@/components/layout/header/mainSection/CartLink';
import LogoLink from '@/components/layout/header/mainSection/LogoLink';
import WishlistLink from '@/components/layout/header/mainSection/WishlistLink';
import React from 'react';
import Searchbox from '@/components/layout/header/mainSection/Searchbox';

export default function MainSection() {
  return (
    <React.Fragment>
      <div className='md:w-1/3 uppercase flex justify-center items-center'>
        <LogoLink />
      </div>
      <div className='md:w-1/3 uppercase flex gap-2 justify-center items-center md:pb-0'>
        <Searchbox />
      </div>
      <div className='md:w-1/3 flex justify-center items-center gap-6 pt-2.5 md:pt-0'>
        <AccountLink />
        <CartLink />
        <WishlistLink />
      </div>
    </React.Fragment>
  );
}
