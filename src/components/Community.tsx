'use client';

import Image from 'next/image';

export function Community() {
  return (
    <div className="p-[1px] rounded-[28px] bg-gradient-to-r from-pink-700 via-purple-800 to-indigo-900">
      <Image 
        src="/img/votes.png"
        alt="Cryptocurrency votes"
        width={1000}
        height={600}
        className="w-full rounded-[28px]"
      />
    </div>
  );
} 