using PP.TestWorker.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PP.TestWorker
{
    public interface IComputeService
    {
        int Add(int a, int b);
        int Diff(int a, int b);
        int Multiply(int a, int b);
    }

    public class ComputeService : IComputeService
    {
        private readonly IComputeRepository _repo;

        public ComputeService(IComputeRepository repo)
        {
            _repo = repo;
        }
        public int Add(int a, int b)
        {
            _repo.Print();
            return a + b;
        }

        public int Diff(int a, int b)
        {
            _repo.Print();
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            _repo.Print();
            return a * b;
        }
    }
}
