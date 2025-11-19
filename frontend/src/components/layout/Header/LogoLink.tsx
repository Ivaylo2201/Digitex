import { Link } from 'react-router';

export function LogoLink() {
  return (
    <Link to='/' className='font-bold text-3xl text-theme-white'>
      digite
      <span className='text-theme-crimson'>x</span>
    </Link>
  );
}
